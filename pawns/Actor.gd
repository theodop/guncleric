extends Node2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var environment
var spacetime
export var is_player = false

export var WALK_SPEED = 1.4
export var RUN_SPEED = 2

enum LegState {STOPPED, MOVING}
enum MoveStyle {STOPPED, WALKING, RUNNING}

var leg_state = LegState.STOPPED
var move_style = MoveStyle.STOPPED
var last_move_vector = Vector2(0,0)
var movement_target_mappos

func _ready():
	environment = get_parent().get_node("Environment")
	spacetime = get_parent().get_node("SpaceTime")
	var starting_pos = environment.map_to_world(Vector2(3,3))
	position = starting_pos

func _process(delta):
	# Called every frame. Delta is time since last frame.
	# Update game logic here.
	#if Input.
	if is_player:
		process_input()
	
	process_movement(delta)
	
func process_input():
	var move_vector = Vector2(0,0)
	var run_key_mod = Input.is_key_pressed(KEY_SHIFT)
	
	if leg_state == LegState.STOPPED:
		if Input.is_key_pressed(KEY_W):
			move_vector.y -= 1
		elif Input.is_key_pressed(KEY_S):
			move_vector.y += 1
		elif Input.is_key_pressed(KEY_A):
			move_vector.x -= 1
		elif Input.is_key_pressed(KEY_D):
			move_vector.x += 1
		
	if move_vector.length() > 0:
		var add_vector = last_move_vector + move_vector
		move_style = MoveStyle.WALKING
		
		if move_style == WALKING and run_key_mod:
			if add_vector.length() == 2:
				move_style = MoveStyle.RUNNING
		
		if environment.can_move(map_pos() + move_vector):
			last_move_vector = move_vector
			movement_target_mappos = map_pos() + move_vector
			leg_state = LegState.MOVING
		else:
			leg_state = LegState.STOPPED
			move_style = MoveStyle.STOPPED

func process_movement(delta):
	if leg_state == LegState.MOVING:
		var target_pos = environment.map_to_world(movement_target_mappos)
		var diff = target_pos - position
		var move_delta = diff.normalized()*delta*environment.points_per_m()*spacetime.time_scale
		
		if move_style == MoveStyle.WALKING:
			move_delta *= WALK_SPEED
		elif move_style == MoveStyle.RUNNING:
			move_delta *= RUN_SPEED
		
		position += move_delta
		
		if diff.length() <= move_delta.length()/2:
			position = target_pos
			leg_state = LegState.STOPPED
			move_style = MoveStyle.STOPPED

func map_pos():
	return environment.world_to_map(position)
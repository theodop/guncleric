extends Node

export var slow_speed = 0.1
export var fast_speed = 1

var time_scale = fast_speed

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	pass

func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
	if Input.is_key_pressed(KEY_CONTROL):
		time_scale = slow_speed
	else:
		time_scale = fast_speed
#	pass
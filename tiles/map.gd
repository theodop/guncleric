extends Node2D

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
var base_tilemap
var tilemaps = {}
export var TILE_WIDTH_M = 2

func _ready():
	# Called when the node is added to the scene for the first time.
	# Initialization here
	base_tilemap = get_child(0)
	
	for i in range(0, get_child_count()):
		var child = get_child(i)
		if child is TileMap and child.has_meta("Type"):
			tilemaps[child.get_meta("Type")] = child
	
	pass

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass

func map_to_world(pos):
	return base_tilemap.map_to_world(pos)
	
func world_to_map(pos):
	return base_tilemap.world_to_map(pos)
	
func can_move(pos):
	var walls = tilemaps["walls"]
	if walls != null:
		return walls.get_cellv(pos) == -1
		
func points_per_m():
	return TILE_WIDTH_M * 16
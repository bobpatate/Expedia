using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ExplorationPoint {
	public uint id {get; private set;}
	public string type {get;private set;}
	public string name {get; private set;}
	public Source source {get; private set;}
	public Position position {get; private set;}
	public string status {get; private set;}

	public double distance {get; private set;}

	public ExplorationPoint(uint _id, string _type, string _name, uint _srcId, uint _systemId, string _posType, double _lat, double _lng, string _status){
		id = _id;
		type = _type;
		name = _name;
		Source _source = new Source(_srcId, _systemId);
		source = _source;
		Position _position = new Position(_posType,_lat, _lng);
		position = _position;
		status = _status;

		distance = GeoDistance.calc(GameMaster.instance.playerLocation.coordinates[0], GameMaster.instance.playerLocation.coordinates[1],
		                            position.coordinates[0], position.coordinates[1], 'K');
	}
}

public class Source{
	public uint srcId {get; private set;}
	public uint systemId {get; private set;}

	public Source(uint _srcId, uint _systemId){
		srcId = _srcId;
		systemId = _systemId;
	}
}

public class Position{
	public string type {get; private set;}
	public List<double> coordinates = new List<double>();

	public Position(string _type, double _lat, double _lng){
		type = _type;
		coordinates.Add(_lat);
		coordinates.Add(_lng);
	}
}

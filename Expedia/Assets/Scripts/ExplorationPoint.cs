using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/*public class ExplorationPoint {
	public uint id {get; set;}
	public string type {get; set;}
	public string name {get; set;}
	public Source source {get; set;}
	public Position position {get; set;}

	public int lat {get; set;}
	public int lng {get; set;}
}*/
/*
public class Source{
	public uint srcId {get; set;}
	public uint systemId {get; set;}
}*/
/*
public class Position{
	public string type {get; set;}
	public List<int> coordinates {get; set;}
	public string status {get; set;}
}*/

public class Source
{
	public string srcId { get; set; }
	public int systemId { get; set; }
}

public class Position
{
	public string type { get; set; }
	public List<double> coordinates { get; set; }
}

public class ExplorationPoint
{
	public string id { get; set; }
	public string type { get; set; }
	public string name { get; set; }
	public Source source { get; set; }
	public Position position { get; set; }
	public string status { get; set; }
}

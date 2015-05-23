﻿using UnityEngine;
using System.Collections;
using System;

public class GeoDistance : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Debug.Log(calc(45.511969, -73.569880, 45.5579957, -73.5518816, 'K'));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//:::                                                                         :::
	//:::  This routine calculates the distance between two points (given the     :::
	//:::  latitude/longitude of those points). It is being used to calculate     :::
	//:::  the distance between two locations using GeoDataSource(TM) products    :::
	//:::                                                                         :::
	//:::  Definitions:                                                           ::
	//:::    South latitudes are negative, east longitudes are positive           :::
	//:::                                                                         :::
	//:::  Passed to function:                                                    :::
	//:::    lat1, lon1 = Latitude and Longitude of point 1 (in decimal degrees)  :::
	//:::    lat2, lon2 = Latitude and Longitude of point 2 (in decimal degrees)  :::
	//:::    unit = the unit you desire for results                               :::
	//:::           where: 'M' is statute miles (default)                         :::
	//:::                  'K' is kilometers                                      ::
	//:::                  'N' is nautical miles                                  :::
	//:::                                                                         :::
	//:::  Worldwide cities and other features databases with latitude longitude  :::
	//:::  are available at http://www.geodatasource.com                          :::
	//:::                                                                         :::
	//:::  For enquiries, please contact sales@geodatasource.com                  :::
	//:::                                                                         :::
	//:::  Official Web site: http://www.geodatasource.com                        :::
	//:::                                                                         :::
	//:::           GeoDataSource.com (C) All Rights Reserved 2015                :::
	//:::                                                                         :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

	private double calc(double lat1, double lon1, double lat2, double lon2, char unit) {
		double theta = lon1 - lon2;
		double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
		dist = Math.Acos(dist);
		dist = rad2deg(dist);
		dist = dist * 60 * 1.1515;
		if (unit == 'K') {
				dist = dist * 1.609344;
		} else if (unit == 'N') {
				dist = dist * 0.8684;
		}
			return (dist);
	}
	
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts decimal degrees to radians             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private double deg2rad(double deg) {
			return (deg * Mathf.PI / 180.0);
	}
		
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	//::  This function converts radians to decimal degrees             :::
	//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	private double rad2deg(double rad) {
			return (rad / Mathf.PI * 180.0);
	}
}

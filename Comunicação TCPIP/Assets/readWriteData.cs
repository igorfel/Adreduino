using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;

public class readWriteData : MonoBehaviour {

	public conexaoTCP connection;
	private bool dataAvaiable;

	/// <summary>
	/// GETTER - Pega o valor que esta no pino descrito pela string.
	/// 			Gets the port value.
	/// </summary>
	/// <returns><c>true</c>, if on, <c>false</c> off.</returns>
	/// <param name="readPort">Read port.</param>
	public bool binRead (string readPort) {
		string stringData = "0";
		byte[] data = new byte[1024];
		if (dataAvaiable) {
			print ("Lendo dados da porta "+ readPort);
			int recv = connection.getClient.Read (data, 0, data.Length);
			stringData = Encoding.ASCII.GetString (data, 0, recv);
			print (stringData);
			
			return bool.Parse (stringData);
		} else {
			Debug.LogError("data is not avaiable");
			return false;
		}
	}
	/// <summary>
	/// GETTER - Pega o valor que esta no pino descrito pela string.
	/// 			Gets the port value.
	/// </summary>
	/// <returns><c>true</c>, if on, <c>false</c> off.</returns>
	/// <param name="readPort">Read port.</param>
	public int analogRead (string readPort) {
		string stringData = "0";
		byte[] data = new byte[1024];

		//if (!connection.getClient.CanRead) {
			//connection.Disconnect ();
			//connection.Connect ();
//		} else {
//			print("Sorry.  You cannot read from this NetworkStream.");
//		}

		//dataAvaiable = connection.getClient.DataAvailable;
		if (connection.getClient.DataAvailable) {
			print ("Lendo dados da porta "+ readPort);
			int recv = connection.getClient.Read (data, 0, data.Length);
			stringData = Encoding.ASCII.GetString (data, 0, recv);
			print (stringData);

			return int.Parse (stringData);
		} else {
			Debug.LogError("data is not avaiable");
			return -1;
		}
	}

	/// <summary>
	/// SETTER - write.
	/// </summary>
	public void binWrite (bool value, string writePort) {


		if (dataAvaiable) {
			print ("Escrevendo: " + value + ", na porta "+ writePort);
			connection.getClient.Write(Encoding.ASCII.GetBytes(writePort), 0, writePort.Length);
		}
	}
	/// <summary>
	/// SETTER
	/// </summary>
	public void analogWrite (int value, string writePort) {
		//connection.Disconnect ();
		//connection.Connect ();

		if (dataAvaiable) {
			print ("Escrevendo: " + value + ", na porta "+ writePort);
			connection.getClient.Write(Encoding.ASCII.GetBytes(writePort), 0, writePort.Length);
		}
	}

	// Use this for initialization
	void Start () {
		connection = Camera.main.GetComponent<conexaoTCP> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if(connection.getListener.Connected)
//			dataAvaiable = connection.getClient.DataAvailable;

		analogRead ("");
	}
}

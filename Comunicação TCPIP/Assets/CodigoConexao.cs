using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;


public class CodigoConexao : MonoBehaviour {

	private TcpClient listener;
	private NetworkStream client;
	byte[] data = new byte[1024];
	int tamanhoValorRecebido;
	VerificaConexao Test;
	// Use this for initialization
	void Start () {
		print ("Escrevendo na porta!");

		listener = new TcpClient("10.0.0.114", 4000);
	}
	
	// Update is called once per frame
	void Update () {
//		Test = new VerificaConexao(listener.GetStream());
		client = listener.GetStream();
		data = new byte[1024];
		if(client.DataAvailable){
			int recv = client.Read(data, 0, data.Length);
			string stringData = Encoding.ASCII.GetString(data, 0, recv);
			print (stringData);
			client.Write(Encoding.ASCII.GetBytes(stringData), 0, stringData.Length);
			client.Flush();
		}
		if(Test.IsConnected)
		{
			print("ok");
		}
	}
	void OnApplicationQuit(){
		client.Close ();
		listener.Close();
	}

}

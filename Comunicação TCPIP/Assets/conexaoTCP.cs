using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;

public class conexaoTCP : MonoBehaviour {
	
	private TcpClient listener;
	private NetworkStream client;
	private VerificaConexao verifCon;
	byte[] data = new byte[1024];
	int tamanhoValorRecebido, porta = 4000;
	string ip = "10.0.0.114";

	// Use this for initialization
	void Start () {
		print ("Escrevendo na porta!");
		Connect ();
	}
	
	// Update is called once per frame
	void Update () {
		if (listener.Connected)
			client = listener.GetStream ();
		//print(listener.Connected);
//		data = new byte[1024];
//		if(client.DataAvailable){
//			print("Processando dados");
//			int recv = client.Read(data, 0, data.Length);
//			string stringData = Encoding.ASCII.GetString(data, 0, recv);
//			print (stringData);
//			client.Write(Encoding.ASCII.GetBytes(stringData), 0, stringData.Length);
//			client.Flush();
//		}
	}
	void OnApplicationQuit(){
		Disconnect ();
	}

	public NetworkStream getClient {
		get {return client;}
	}
	public TcpClient getListener {
		get{return listener;}
	}
	public String getIp {
		get {return ip;}
	}
	public int getPort {
		get{return porta;}
	}

	public void Connect () {
		listener = new TcpClient ();
		listener.Connect (ip, porta);
		client = listener.GetStream();
		print ("Connected");
	}

	public void Disconnect (){
		client.Close ();
		listener.Close();
		print ("Disconnected");
	}
}

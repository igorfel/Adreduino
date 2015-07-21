using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class VerificaConexao : NetworkStream {

	public VerificaConexao(Socket socket) :
		base(socket)
	{

	}
	// You can use the Socket method to examine the underlying Socket.
	public bool IsConnected
	{
		get
		{
			return this.Socket.Connected;
		} 
	}
	
	public bool CanCommunicate
	{
		get
		{
			if (!this.Readable | !this.Writeable)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}

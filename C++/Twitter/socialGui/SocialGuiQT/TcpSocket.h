#pragma once
#include <cstdint>
#include <string>
#include <array>
#include <basetsd.h>

class TcpSocket
{
private:
	using SocketHandle = UINT_PTR;
	static const SocketHandle InvalidSocketHandle;

public:
	TcpSocket();
	~TcpSocket();

	bool Listen(uint16_t remotePort);
	TcpSocket Accept();

	bool Connect(const std::string& remoteAddress, uint16_t remotePort);
	bool Send(const void* data, int size);
	bool Receive(void* data, int size, int& recieved);
    void operator = (const TcpSocket& s){
        m_socket = s.m_socket;

    }
    static std::string ReceiveAndSend(const std::string&);

private:
	TcpSocket(SocketHandle socketHandle);

private:
	SocketHandle m_socket;
};


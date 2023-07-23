#include<stdio.h>
#include<WinSock2.h>

#pragma comment(lib, "Ws2_32.lib")

#define PORT 27001
#define BUF_SIZE 1024

int main() {
	WSADATA wsadata;
	WSAStartup(MAKEWORD(2, 2), &wsadata);
	SOCKET sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	struct sockaddr_in recv_addr;
	recv_addr.sin_family = AF_INET;
	recv_addr.sin_port = htons(PORT);
	recv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	bind(sock, (SOCKADDR*)&recv_addr, sizeof recv_addr);

	char buf[BUF_SIZE];
	struct sockaddr_in sender_addr;
	int sender_address_size = sizeof(sender_addr);

	while (TRUE)
	{
		int length = recvfrom(sock, buf, BUF_SIZE, 0, 
			(SOCKADDR*)&sender_addr, &sender_address_size);

		buf[length] = '\0';
		if (strcmp(buf, "exit") == 0) {
			printf("Goodbye");
			break;
		}
		printf("%s\n", buf);

	}
	closesocket(sock);
	WSACleanup();
	return 0;
}
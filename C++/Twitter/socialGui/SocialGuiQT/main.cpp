#include "widget.h"
#include "loginwidget.h"
#include "menu.h"
#include <QApplication>
#include <iostream>
#include <array>



int main(int argc, char *argv[])
{




        /*
        std::string message;

        std::string recMess;
        std::array<char, 512> receiveBuffer = {'\0'};
        std::cout << receiveBuffer.data();

        std::cout << "\nDATI MESAJ: ";
        std::cin >> message;
        //std::string message = "this is a test :)";
        //std::cout << "Sending message: " << message << std::endl;
        bool result = socket.Send(message.c_str(), message.size());
        if (result)
        {
            int revieved;
            socket.Receive(receiveBuffer.data(), receiveBuffer.size(), revieved);
            std::cout << "Received: ";

            //std::copy(receiveBuffer.begin(), receiveBuffer.begin() + revieved, std::ostream_iterator<char>(std::cout, ""));
            std::cout << receiveBuffer.data();

            //for (const auto& s : receiveBuffer)
                //std::cout << (char)s << ' ';
            //std::cout<< << std::endl;
        }*/

    QApplication a(argc, argv);
//    Widget w;
//    w.show();


    LoginWidget login;
    //login.SetSocket(socket);
    login.show();



    return a.exec();
}

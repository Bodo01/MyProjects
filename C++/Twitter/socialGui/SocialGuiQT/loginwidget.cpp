#include "loginwidget.h"
#include "ui_loginwidget.h"
#include <QMessageBox>
#include <QDebug>
#include "menu.h"


LoginWidget::LoginWidget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::LoginWidget)
{
    ui->setupUi(this);
}

LoginWidget::~LoginWidget()
{
    delete ui;
}
void LoginWidget::SetSocket(TcpSocket sock){
    //socket = sock;

}
void LoginWidget::on_ConnectButton_clicked()
{

    std::string username = ui->usernameEdit->text().toStdString();
    std::string password = ui->passwordEdit->text().toStdString();




    std::string userAndPass = "LOGIN:USERNAME="+username+"PASSWORD="+password;
    std::string response = TcpSocket::ReceiveAndSend(userAndPass);




    if (response=="ACCEPT") {


        //displayProfile *prof= new displayProfile();
        //prof->show();

        hide();
        menu = new Menu();
        menu->SetUsername(username);
        menu->show();

    }
    else QMessageBox::information(this,"Login", "Username not found!");

}


void LoginWidget::on_pushButton_clicked()
{

    regpage= new registerpage();

    regpage->show();


}


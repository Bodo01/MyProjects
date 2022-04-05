#ifndef LOGINWIDGET_H
#define LOGINWIDGET_H

#include <QWidget>
#include "menu.h"
#include "registerpage.h"
#include "TcpSocket.h"
#include <array>

namespace Ui {
class LoginWidget;
}

class LoginWidget : public QWidget
{
    Q_OBJECT

public:
    explicit LoginWidget(QWidget *parent = nullptr);
    ~LoginWidget();
    void SetSocket(TcpSocket sock);

private slots:
    void on_ConnectButton_clicked();

    void on_pushButton_clicked();
private:
    //TcpSocket socket;
    Ui::LoginWidget *ui;
    Menu* menu;
    registerpage* regpage;
};

#endif // LOGINWIDGET_H

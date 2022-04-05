#ifndef REGISTERPAGE_H
#define REGISTERPAGE_H
#include <iostream>
#include <QWidget>
#include <array>
#include <TcpSocket.h>
#include <QBuffer>

namespace Ui {
class registerpage;
}

class registerpage : public QWidget
{
    Q_OBJECT

public:
    explicit registerpage(QWidget *parent = nullptr);
    ~registerpage();

private slots:
    void on_uploadpicture_clicked();

    void on_pushButton_clicked();

private:
    Ui::registerpage *ui;
    QString profilepicture;
};

#endif // REGISTERPAGE_H

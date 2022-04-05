#include "follow.h"
#include "ui_follow.h"

Follow::Follow(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Follow)
{
    ui->setupUi(this);
}

Follow::~Follow()
{
    delete ui;
}

void Follow::addfollow(QString usernameToFollow)
{
    //server checks if username exists

    //server checks if user is followed or not followed

}

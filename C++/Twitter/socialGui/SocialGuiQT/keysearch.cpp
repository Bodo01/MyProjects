#include "keysearch.h"
#include "ui_keysearch.h"

keySearch::keySearch(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::keySearch)
{
    ui->setupUi(this);
}

keySearch::~keySearch()
{
    delete ui;
}

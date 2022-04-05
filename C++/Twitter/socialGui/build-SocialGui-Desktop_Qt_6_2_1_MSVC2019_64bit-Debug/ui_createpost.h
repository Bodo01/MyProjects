/********************************************************************************
** Form generated from reading UI file 'createpost.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CREATEPOST_H
#define UI_CREATEPOST_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPlainTextEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CreatePost
{
public:
    QPlainTextEdit *plainTextEdit;
    QLabel *label;
    QPushButton *pushButton;
    QPushButton *uploadbutton;
    QLabel *imagelabel;

    void setupUi(QWidget *CreatePost)
    {
        if (CreatePost->objectName().isEmpty())
            CreatePost->setObjectName(QString::fromUtf8("CreatePost"));
        CreatePost->resize(1295, 653);
        CreatePost->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);"));
        plainTextEdit = new QPlainTextEdit(CreatePost);
        plainTextEdit->setObjectName(QString::fromUtf8("plainTextEdit"));
        plainTextEdit->setGeometry(QRect(30, 50, 611, 421));
        plainTextEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);"));
        label = new QLabel(CreatePost);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(50, 10, 161, 31));
        QFont font;
        font.setFamilies({QString::fromUtf8("Sitka Small")});
        font.setPointSize(10);
        label->setFont(font);
        pushButton = new QPushButton(CreatePost);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(1080, 570, 101, 51));
        QFont font1;
        font1.setPointSize(15);
        pushButton->setFont(font1);
        pushButton->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 20px;\n"
"color: rgb(235, 235, 222);"));
        uploadbutton = new QPushButton(CreatePost);
        uploadbutton->setObjectName(QString::fromUtf8("uploadbutton"));
        uploadbutton->setGeometry(QRect(670, 480, 131, 51));
        QFont font2;
        font2.setPointSize(10);
        uploadbutton->setFont(font2);
        uploadbutton->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 20px;\n"
"color: rgb(235, 235, 222);"));
        imagelabel = new QLabel(CreatePost);
        imagelabel->setObjectName(QString::fromUtf8("imagelabel"));
        imagelabel->setGeometry(QRect(660, 50, 611, 421));
        imagelabel->setScaledContents(true);

        retranslateUi(CreatePost);

        QMetaObject::connectSlotsByName(CreatePost);
    } // setupUi

    void retranslateUi(QWidget *CreatePost)
    {
        CreatePost->setWindowTitle(QCoreApplication::translate("CreatePost", "Form", nullptr));
        label->setText(QCoreApplication::translate("CreatePost", "Write something:     ", nullptr));
        pushButton->setText(QCoreApplication::translate("CreatePost", "Post", nullptr));
        uploadbutton->setText(QCoreApplication::translate("CreatePost", "Upload an image", nullptr));
        imagelabel->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class CreatePost: public Ui_CreatePost {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CREATEPOST_H

/********************************************************************************
** Form generated from reading UI file 'registerpage.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_REGISTERPAGE_H
#define UI_REGISTERPAGE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDateEdit>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_registerpage
{
public:
    QLabel *label;
    QLabel *label_2;
    QPushButton *uploadpicture;
    QLabel *imagelabel;
    QLabel *label_4;
    QDateEdit *dateEdit;
    QLabel *label_3;
    QComboBox *comboBox;
    QLabel *label_5;
    QPushButton *pushButton;
    QLineEdit *usernameedit;
    QLineEdit *passwordedit;

    void setupUi(QWidget *registerpage)
    {
        if (registerpage->objectName().isEmpty())
            registerpage->setObjectName(QString::fromUtf8("registerpage"));
        registerpage->resize(1315, 650);
        QFont font;
        font.setPointSize(13);
        registerpage->setFont(font);
        registerpage->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);"));
        label = new QLabel(registerpage);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(30, 19, 91, 31));
        QFont font1;
        font1.setPointSize(10);
        label->setFont(font1);
        label->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border-radius: 10px;"));
        label_2 = new QLabel(registerpage);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(30, 120, 91, 31));
        label_2->setFont(font1);
        label_2->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border-radius: 10px;"));
        uploadpicture = new QPushButton(registerpage);
        uploadpicture->setObjectName(QString::fromUtf8("uploadpicture"));
        uploadpicture->setGeometry(QRect(700, 130, 121, 31));
        uploadpicture->setFont(font1);
        uploadpicture->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 10px;"));
        imagelabel = new QLabel(registerpage);
        imagelabel->setObjectName(QString::fromUtf8("imagelabel"));
        imagelabel->setGeometry(QRect(924, 15, 201, 161));
        imagelabel->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);"));
        imagelabel->setPixmap(QPixmap(QString::fromUtf8("C:/Users/asusrog/Desktop/val/1.jpg")));
        imagelabel->setScaledContents(true);
        label_4 = new QLabel(registerpage);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(700, 20, 201, 101));
        QFont font2;
        font2.setPointSize(11);
        label_4->setFont(font2);
        label_4->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);"));
        dateEdit = new QDateEdit(registerpage);
        dateEdit->setObjectName(QString::fromUtf8("dateEdit"));
        dateEdit->setGeometry(QRect(30, 280, 231, 51));
        QFont font3;
        font3.setPointSize(16);
        dateEdit->setFont(font3);
        dateEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border: none;"));
        label_3 = new QLabel(registerpage);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(30, 230, 111, 31));
        label_3->setFont(font1);
        label_3->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"color: rgb(222, 222, 190);\n"
"border-radius: 10px;"));
        comboBox = new QComboBox(registerpage);
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->setObjectName(QString::fromUtf8("comboBox"));
        comboBox->setGeometry(QRect(30, 400, 231, 51));
        comboBox->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border: none;"));
        label_5 = new QLabel(registerpage);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(30, 350, 71, 31));
        label_5->setFont(font1);
        label_5->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border-radius: 10px;\n"
"color: rgb(222, 222, 190);"));
        pushButton = new QPushButton(registerpage);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(1130, 570, 161, 61));
        pushButton->setMaximumSize(QSize(161, 61));
        QFont font4;
        font4.setPointSize(17);
        pushButton->setFont(font4);
        pushButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        usernameedit = new QLineEdit(registerpage);
        usernameedit->setObjectName(QString::fromUtf8("usernameedit"));
        usernameedit->setGeometry(QRect(30, 60, 231, 41));
        usernameedit->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"font: 12pt \"MS Shell Dlg 2\";\n"
"border: none;"));
        passwordedit = new QLineEdit(registerpage);
        passwordedit->setObjectName(QString::fromUtf8("passwordedit"));
        passwordedit->setGeometry(QRect(30, 170, 231, 41));
        passwordedit->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"font: 12pt \"MS Shell Dlg 2\";\n"
"border: none;"));
        QWidget::setTabOrder(uploadpicture, comboBox);
        QWidget::setTabOrder(comboBox, pushButton);
        QWidget::setTabOrder(pushButton, usernameedit);
        QWidget::setTabOrder(usernameedit, passwordedit);
        QWidget::setTabOrder(passwordedit, dateEdit);

        retranslateUi(registerpage);

        QMetaObject::connectSlotsByName(registerpage);
    } // setupUi

    void retranslateUi(QWidget *registerpage)
    {
        registerpage->setWindowTitle(QCoreApplication::translate("registerpage", "Form", nullptr));
        label->setText(QCoreApplication::translate("registerpage", " Username:", nullptr));
        label_2->setText(QCoreApplication::translate("registerpage", " Password:", nullptr));
        uploadpicture->setText(QCoreApplication::translate("registerpage", "Upload picture", nullptr));
        imagelabel->setText(QString());
        label_4->setText(QCoreApplication::translate("registerpage", "<html><head/><body><p>Upload a profile picture,</p><p>recommended resolution</p><p> 200x200 px</p><p><br/></p></body></html>", nullptr));
        label_3->setText(QCoreApplication::translate("registerpage", " Date of birth:", nullptr));
        comboBox->setItemText(0, QCoreApplication::translate("registerpage", "Other", nullptr));
        comboBox->setItemText(1, QCoreApplication::translate("registerpage", "Male", nullptr));
        comboBox->setItemText(2, QCoreApplication::translate("registerpage", "Female", nullptr));

        label_5->setText(QCoreApplication::translate("registerpage", " Gender:", nullptr));
        pushButton->setText(QCoreApplication::translate("registerpage", "REGISTER", nullptr));
        usernameedit->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class registerpage: public Ui_registerpage {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_REGISTERPAGE_H

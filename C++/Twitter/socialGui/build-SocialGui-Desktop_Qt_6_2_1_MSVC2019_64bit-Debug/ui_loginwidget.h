/********************************************************************************
** Form generated from reading UI file 'loginwidget.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_LOGINWIDGET_H
#define UI_LOGINWIDGET_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_LoginWidget
{
public:
    QGroupBox *groupBox;
    QPushButton *ConnectButton;
    QWidget *layoutWidget;
    QHBoxLayout *horizontalLayout;
    QLabel *UsernameLabel;
    QLineEdit *usernameEdit;
    QWidget *layoutWidget_2;
    QHBoxLayout *horizontalLayout_2;
    QLabel *PasswordLabel;
    QLineEdit *passwordEdit;
    QPushButton *pushButton;

    void setupUi(QWidget *LoginWidget)
    {
        if (LoginWidget->objectName().isEmpty())
            LoginWidget->setObjectName(QString::fromUtf8("LoginWidget"));
        LoginWidget->resize(1331, 696);
        LoginWidget->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);"));
        groupBox = new QGroupBox(LoginWidget);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        groupBox->setGeometry(QRect(380, 80, 521, 391));
        QFont font;
        font.setFamilies({QString::fromUtf8("Bahnschrift")});
        font.setPointSize(22);
        font.setBold(true);
        font.setItalic(true);
        groupBox->setFont(font);
        groupBox->setAutoFillBackground(false);
        groupBox->setStyleSheet(QString::fromUtf8("background-color: rgb(79, 71, 71);\n"
"border: none;"));
        ConnectButton = new QPushButton(groupBox);
        ConnectButton->setObjectName(QString::fromUtf8("ConnectButton"));
        ConnectButton->setGeometry(QRect(180, 300, 141, 61));
        QFont font1;
        font1.setFamilies({QString::fromUtf8("Sitka Text")});
        font1.setPointSize(16);
        font1.setBold(true);
        font1.setItalic(false);
        ConnectButton->setFont(font1);
        ConnectButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));
        layoutWidget = new QWidget(groupBox);
        layoutWidget->setObjectName(QString::fromUtf8("layoutWidget"));
        layoutWidget->setGeometry(QRect(40, 144, 461, 51));
        horizontalLayout = new QHBoxLayout(layoutWidget);
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        UsernameLabel = new QLabel(layoutWidget);
        UsernameLabel->setObjectName(QString::fromUtf8("UsernameLabel"));
        QFont font2;
        font2.setFamilies({QString::fromUtf8("Verdana")});
        font2.setPointSize(12);
        font2.setBold(false);
        font2.setItalic(false);
        UsernameLabel->setFont(font2);
        UsernameLabel->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));

        horizontalLayout->addWidget(UsernameLabel);

        usernameEdit = new QLineEdit(layoutWidget);
        usernameEdit->setObjectName(QString::fromUtf8("usernameEdit"));
        usernameEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);\n"
"font: 12pt \"MS Shell Dlg 2\";\n"
"border: none;"));

        horizontalLayout->addWidget(usernameEdit);

        layoutWidget_2 = new QWidget(groupBox);
        layoutWidget_2->setObjectName(QString::fromUtf8("layoutWidget_2"));
        layoutWidget_2->setGeometry(QRect(40, 214, 461, 51));
        horizontalLayout_2 = new QHBoxLayout(layoutWidget_2);
        horizontalLayout_2->setObjectName(QString::fromUtf8("horizontalLayout_2"));
        horizontalLayout_2->setContentsMargins(0, 0, 0, 0);
        PasswordLabel = new QLabel(layoutWidget_2);
        PasswordLabel->setObjectName(QString::fromUtf8("PasswordLabel"));
        PasswordLabel->setFont(font2);
        PasswordLabel->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));

        horizontalLayout_2->addWidget(PasswordLabel);

        passwordEdit = new QLineEdit(layoutWidget_2);
        passwordEdit->setObjectName(QString::fromUtf8("passwordEdit"));
        passwordEdit->setStyleSheet(QString::fromUtf8("background-color: rgb(235, 235, 222);\n"
"font: 12pt \"MS Shell Dlg 2\";\n"
"border: none;"));

        horizontalLayout_2->addWidget(passwordEdit);

        pushButton = new QPushButton(LoginWidget);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(1070, 580, 231, 61));
        QFont font3;
        font3.setPointSize(11);
        font3.setBold(false);
        font3.setItalic(false);
        pushButton->setFont(font3);
        pushButton->setStyleSheet(QString::fromUtf8("background-color: rgb(119, 119, 70);\n"
"border-radius: 20px;"));

        retranslateUi(LoginWidget);

        QMetaObject::connectSlotsByName(LoginWidget);
    } // setupUi

    void retranslateUi(QWidget *LoginWidget)
    {
        LoginWidget->setWindowTitle(QCoreApplication::translate("LoginWidget", "Form", nullptr));
        groupBox->setTitle(QCoreApplication::translate("LoginWidget", "Login", nullptr));
        ConnectButton->setText(QCoreApplication::translate("LoginWidget", "Connect", nullptr));
#if QT_CONFIG(shortcut)
        ConnectButton->setShortcut(QCoreApplication::translate("LoginWidget", "Return", nullptr));
#endif // QT_CONFIG(shortcut)
        UsernameLabel->setText(QCoreApplication::translate("LoginWidget", "<html><head/><body><p><span style=\" font-weight:600;\"> Username: </span></p></body></html>", nullptr));
        PasswordLabel->setText(QCoreApplication::translate("LoginWidget", "<html><head/><body><p><span style=\" font-weight:600;\"> Password: </span></p></body></html>", nullptr));
        pushButton->setText(QCoreApplication::translate("LoginWidget", "Register a new account", nullptr));
    } // retranslateUi

};

namespace Ui {
    class LoginWidget: public Ui_LoginWidget {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_LOGINWIDGET_H

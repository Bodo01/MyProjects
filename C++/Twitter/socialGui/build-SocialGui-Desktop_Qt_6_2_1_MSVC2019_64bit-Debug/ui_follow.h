/********************************************************************************
** Form generated from reading UI file 'follow.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_FOLLOW_H
#define UI_FOLLOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Follow
{
public:

    void setupUi(QWidget *Follow)
    {
        if (Follow->objectName().isEmpty())
            Follow->setObjectName(QString::fromUtf8("Follow"));
        Follow->resize(400, 300);

        retranslateUi(Follow);

        QMetaObject::connectSlotsByName(Follow);
    } // setupUi

    void retranslateUi(QWidget *Follow)
    {
        Follow->setWindowTitle(QCoreApplication::translate("Follow", "Form", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Follow: public Ui_Follow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FOLLOW_H

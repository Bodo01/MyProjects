/********************************************************************************
** Form generated from reading UI file 'keysearch.ui'
**
** Created by: Qt User Interface Compiler version 6.2.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_KEYSEARCH_H
#define UI_KEYSEARCH_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_keySearch
{
public:

    void setupUi(QWidget *keySearch)
    {
        if (keySearch->objectName().isEmpty())
            keySearch->setObjectName(QString::fromUtf8("keySearch"));
        keySearch->resize(674, 485);

        retranslateUi(keySearch);

        QMetaObject::connectSlotsByName(keySearch);
    } // setupUi

    void retranslateUi(QWidget *keySearch)
    {
        keySearch->setWindowTitle(QCoreApplication::translate("keySearch", "Form", nullptr));
    } // retranslateUi

};

namespace Ui {
    class keySearch: public Ui_keySearch {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_KEYSEARCH_H

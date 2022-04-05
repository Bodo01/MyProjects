#ifndef KEYSEARCH_H
#define KEYSEARCH_H

#include <QWidget>

namespace Ui {
class keySearch;
}

class keySearch : public QWidget
{
    Q_OBJECT

public:
    explicit keySearch(QWidget *parent = nullptr);
    ~keySearch();

private:
    Ui::keySearch *ui;
};

#endif // KEYSEARCH_H

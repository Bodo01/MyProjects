package Classes;

import java.util.Objects;

public class Echipa {
    private int idEchipa;
    private String numeEchipa;

    public int getIdEchipa() {
        return idEchipa;
    }

    public void setIdEchipa(int idEchipa) {
        this.idEchipa = idEchipa;
    }

    public String getNumeEchipa() {
        return numeEchipa;
    }

    public void setNumeEchipa(String numeEchipa) {
        this.numeEchipa = numeEchipa;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Echipa that = (Echipa) o;
        return idEchipa == that.idEchipa && Objects.equals(numeEchipa, that.numeEchipa);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idEchipa, numeEchipa);
    }
}

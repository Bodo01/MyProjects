package Classes;

import java.util.Objects;

public class Etapa {
    private int idEtapa;

    private String denumire;

    private Boolean incheiata;

    public int getIdEtapa() {
        return idEtapa;
    }

    public void setIdEtapa(int idEtapa) {
        this.idEtapa = idEtapa;
    }

    public String getDenumire() {
        return denumire;
    }

    public void setDenumire(String denumire) {
        this.denumire = denumire;
    }

    public Boolean getIncheiata() {
        return incheiata;
    }

    public void setIncheiata(Boolean incheiata) {
        this.incheiata = incheiata;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Etapa that = (Etapa) o;
        return idEtapa == that.idEtapa && Objects.equals(denumire, that.denumire) && Objects.equals(incheiata, that.incheiata);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idEtapa, denumire, incheiata);
    }
}



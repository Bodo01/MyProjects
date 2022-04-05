package Classes;

import java.util.Objects;

public class Participant {
    private int idParticipant;

    private int idPersoana;

    private int idEtapa;

    private Integer punctaj;

    public int getIdParticipant() {
        return idParticipant;
    }

    public void setIdParticipant(int idParticipant) {
        this.idParticipant = idParticipant;
    }

    public int getIdPersoana() {
        return idPersoana;
    }

    public void setIdPersoana(int idPersoana) {
        this.idPersoana = idPersoana;
    }

    public int getIdEtapa() {
        return idEtapa;
    }

    public void setIdEtapa(int idEtapa) {
        this.idEtapa = idEtapa;
    }

    public Integer getPunctaj() {
        return punctaj;
    }

    public void setPunctaj(Integer punctaj) {
        this.punctaj = punctaj;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Participant that = (Participant) o;
        return idParticipant == that.idParticipant && idPersoana == that.idPersoana && idEtapa == that.idEtapa && Objects.equals(punctaj, that.punctaj);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idParticipant, idPersoana, idEtapa, punctaj);
    }
}

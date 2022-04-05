package entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "participant", schema = "public", catalog = "competitie2")
public class ParticipantEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_participant", nullable = false)
    private int idParticipant;
    @Basic
    @Column(name = "id_persoana", nullable = false)
    private int idPersoana;
    @Basic
    @Column(name = "id_etapa", nullable = false)
    private int idEtapa;
    @Basic
    @Column(name = "punctaj", nullable = true)
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
        ParticipantEntity that = (ParticipantEntity) o;
        return idParticipant == that.idParticipant && idPersoana == that.idPersoana && idEtapa == that.idEtapa && Objects.equals(punctaj, that.punctaj);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idParticipant, idPersoana, idEtapa, punctaj);
    }
}

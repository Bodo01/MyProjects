package entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "echipa", schema = "public", catalog = "competitie2")
public class EchipaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_echipa", nullable = false)
    private int idEchipa;
    @Basic
    @Column(name = "nume_echipa", nullable = true, length = -1)
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
        EchipaEntity that = (EchipaEntity) o;
        return idEchipa == that.idEchipa && Objects.equals(numeEchipa, that.numeEchipa);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idEchipa, numeEchipa);
    }
}

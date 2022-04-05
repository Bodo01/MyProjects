package entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "etapa", schema = "public", catalog = "competitie2")
public class EtapaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_etapa", nullable = false)
    private int idEtapa;
    @Basic
    @Column(name = "denumire", nullable = true, length = -1)
    private String denumire;
    @Basic
    @Column(name = "incheiata", nullable = true)
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
        EtapaEntity that = (EtapaEntity) o;
        return idEtapa == that.idEtapa && Objects.equals(denumire, that.denumire) && Objects.equals(incheiata, that.incheiata);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idEtapa, denumire, incheiata);
    }
}

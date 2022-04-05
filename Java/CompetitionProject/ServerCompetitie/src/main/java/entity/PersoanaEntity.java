package entity;

import net.bytebuddy.implementation.bind.annotation.Default;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "persoana", schema = "public", catalog = "competitie2")
public class PersoanaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_persoana", nullable = false)
    private int idPersoana;
    @Basic
    @Column(name = "id_echipa", nullable = false)
    private int idEchipa;
    @Basic
    @Column(name = "nume", nullable = true, length = -1)
    private String nume;
    @Basic
    @Column(name = "username", nullable = true, length = -1)
    private String username;
    @Basic
    @Column(name = "rol", nullable = true, length = -1)
    private String rol;
    @Basic
    @Column(name = "punctaj", nullable = true, length = -1)
    private int punctaj;

    public int getIdPersoana() {
        return idPersoana;
    }

    public void setIdPersoana(int idPersoana) {
        this.idPersoana = idPersoana;
    }

    public int getIdEchipa() {
        return idEchipa;
    }

    public void setIdEchipa(int idEchipa) {
        this.idEchipa = idEchipa;
    }

    public String getNume() {
        return nume;
    }

    public void setNume(String nume) {
        this.nume = nume;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getRol() {
        return rol;
    }

    public void setRol(String rol) {
        this.rol = rol;
    }

    public int getPunctaj(){return punctaj;}

    public void setPunctaj(int punctaj ){this.punctaj=punctaj;}

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        PersoanaEntity that = (PersoanaEntity) o;
        return idPersoana == that.idPersoana && idEchipa == that.idEchipa && Objects.equals(nume, that.nume) && Objects.equals(username, that.username) && Objects.equals(rol, that.rol);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idPersoana, idEchipa, nume, username, rol);
    }
}

package Classes;

import java.util.Objects;

public class Persoana {


    private int idPersoana;

    private int idEchipa;

    private String nume;

    private String username;

    private String rol;

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
        Persoana that = (Persoana) o;
        return idPersoana == that.idPersoana && idEchipa == that.idEchipa && Objects.equals(nume, that.nume) && Objects.equals(username, that.username) && Objects.equals(rol, that.rol);
    }

    @Override
    public int hashCode() {
        return Objects.hash(idPersoana, idEchipa, nume, username, rol);
    }
}

package com.example.youssef.goclimber;

import android.app.Activity;
import android.app.Fragment;
import android.content.Intent;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.RatingBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.Fragments.ParcoursDispo;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.Difficulte;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.Classes.StyleVoie;
import com.example.youssef.goclimber.data.Classes.TypeRéussite;
import com.example.youssef.goclimber.data.Classes.Utilisateur;
import com.example.youssef.goclimber.data.CritiqueDataSource;
import com.example.youssef.goclimber.data.DifficulteDataSource;
import com.example.youssef.goclimber.data.UtilisateurDataSource;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Locale;

public class FicheDeParcours extends Activity {

    private Parcours infoParcoursParam;
    private String typeParcoursParam;
    private Spinner spinnerDiff;
    private Spinner spinnerFacon;
    private Spinner spinnerStyleVoie;
    private TextView txtNomOuvreur;
    private TextView txtDescripParcours;
    private TextView txtCouleurPrise;
    private TextView txtOuverture;
    private TextView lblStyleVoie;
    private RatingBar rbCote;
    private RatingBar rbCritique;
    private int idConnect;

    private StyleVoie styleSelect;
    private Difficulte diffSelect;
    private TypeRéussite typeReussSelect;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fiche_de_parcours);
        Bundle bundle = getIntent().getExtras();
        infoParcoursParam = (Parcours) bundle.get("ParcoursChoisi");
        typeParcoursParam = bundle.getString("TypeParcours");
        idConnect = bundle.getInt("idConnect");

        spinnerDiff = (Spinner) this.findViewById(R.id.spinnerDiff);
        spinnerFacon = (Spinner) this.findViewById(R.id.spinnerReussite);
        spinnerStyleVoie = (Spinner) this.findViewById(R.id.spinnerStyleVoie);
        txtNomOuvreur = (TextView) this.findViewById(R.id.txtNomOuvreur);
        txtDescripParcours = (TextView) this.findViewById(R.id.txtDescripParcours);
        txtCouleurPrise = (TextView) this.findViewById(R.id.txtCouleurParcours);
        txtOuverture = (TextView) this.findViewById(R.id.txtDateOuvertureParcours);
        rbCote = (RatingBar) this.findViewById(R.id.ratingBarFicheParcours);
        rbCritique = (RatingBar) this.findViewById(R.id.ratingBarCritique);
        lblStyleVoie = (TextView) this.findViewById(R.id.textView2);

        UtilisateurDataSource userDS = new UtilisateurDataSource(this);
        userDS.open();
        //Utilisateur user = userDS.getUtilisateur(infoParcoursParam.getM_usagerOuv());
        userDS.close();

        SimpleDateFormat format1 = new SimpleDateFormat("yyyy-MM-dd", Locale.CANADA);
        String formatted = format1.format(infoParcoursParam.getM_dateOuverture().getTime());


        CritiqueDataSource critiqueDS = new CritiqueDataSource(this);
        critiqueDS.open();
        ArrayList<Critique> lstCritique;
        //lstCritique = critiqueDS.getCritiqueByParcours(infoParcoursParam.getM_idParcours());
        critiqueDS.close();

        float nbetoile;
        /*if(!lstCritique.isEmpty())
        {
            Critique maCritique = lstCritique.get(0);
            nbetoile = maCritique.getM_nbEtoile();
        }
        else
        {
            nbetoile = 0;
        }*/

        ArrayList<StyleVoie> lstChoix = new ArrayList<>();
        lstChoix.add(StyleVoie.Moulinette);
        lstChoix.add(StyleVoie.PremierDeCordée);
        ArrayList<Difficulte> lstDifficulte = new ArrayList<>();
        DifficulteDataSource diffDS = new DifficulteDataSource(this);
        diffDS.open();
        if(typeParcoursParam.equals("Bloc")){
            lstDifficulte = diffDS.getDiffBloc();
            spinnerStyleVoie.setVisibility(View.GONE);
            lblStyleVoie.setVisibility(View.GONE);
        }else{
            lstDifficulte = diffDS.getDiffVoie();
        }
        diffDS.close();

        spinnerStyleVoie.setAdapter(new ArrayAdapter<StyleVoie>(spinnerStyleVoie.getContext(), android.R.layout.simple_spinner_item, lstChoix));
        spinnerFacon.setAdapter(new ArrayAdapter<TypeRéussite>(spinnerFacon.getContext(), android.R.layout.simple_spinner_item, TypeRéussite.values()));
        spinnerDiff.setAdapter(new ArrayAdapter<Difficulte>(spinnerDiff.getContext(), android.R.layout.simple_spinner_item, lstDifficulte));
        //txtNomOuvreur.setText(user.getM_prenom() + " " + user.getM_nom());
        txtDescripParcours.setText(infoParcoursParam.toString());
        txtCouleurPrise.setText(infoParcoursParam.getM_couleurPrise().toString());
        txtOuverture.setText("Ouverture: " + formatted);
        //rbCote.setRating(nbetoile);


        spinnerStyleVoie.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                styleSelect = (StyleVoie) spinnerStyleVoie.getItemAtPosition(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spinnerFacon.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                typeReussSelect = (TypeRéussite) spinnerFacon.getItemAtPosition(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spinnerDiff.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                diffSelect = (Difficulte) spinnerDiff.getItemAtPosition(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

    }


    public void btnReussirOnClick(View v)
    {
        CritiqueDataSource critiqueDS = new CritiqueDataSource(this);
        critiqueDS.open();
        Critique maCritique;
       /* if(typeParcoursParam.equals("Voie")) {
            maCritique = new Critique(0,infoParcoursParam.getM_idParcours(), idConnect, rbCritique.getRating(), styleSelect, typeReussSelect, diffSelect.toString());
        }
        else {
            maCritique = new Critique(0,infoParcoursParam.getM_idParcours(), idConnect, rbCritique.getRating(), StyleVoie.Aucun, typeReussSelect, diffSelect.toString());
        }*/

        Toast.makeText(this, "Fiche de réussite envoyée.", Toast.LENGTH_LONG).show();
       // critiqueDS.insert(maCritique);
        critiqueDS.close();
        Intent i = new Intent(this, MainActivity.class);
        i.putExtra("idConnecter", idConnect);
        startActivity(i);
    }
}

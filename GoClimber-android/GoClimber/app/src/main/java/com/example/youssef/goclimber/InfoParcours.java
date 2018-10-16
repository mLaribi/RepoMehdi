package com.example.youssef.goclimber;

import android.media.Rating;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.Fragments.Profile;
import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.Classes.Utilisateur;
import com.example.youssef.goclimber.data.CritiqueDataSource;
import com.example.youssef.goclimber.data.UtilisateurDataSource;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Locale;

public class InfoParcours extends AppCompatActivity {

    private Parcours infoParcoursParam = new Parcours();
    private TextView txtNomParcours;
    private TextView txtNomOuvreur;
    private TextView txtCouleur;
    private TextView txtDateOuverture;
    private RatingBar rbParcours, rbModifCritique;
    private int idConnect;
    private Button btnModiff;
    private Critique maCritique = new Critique();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info_parcours);
        Bundle bundle = getIntent().getExtras();
        infoParcoursParam = (Parcours) bundle.get("ParcoursChoisi");
        idConnect = bundle.getInt("idConnect");
        txtNomParcours = (TextView) findViewById(R.id.txtNomParcoursInfo);
        txtNomOuvreur = (TextView) findViewById(R.id.txtOuvreurInfo);
        txtCouleur = (TextView) findViewById(R.id.txtCouleurParcours);
        txtDateOuverture = (TextView) findViewById(R.id.txtDateOuvertureParcours);
        rbParcours = (RatingBar) findViewById(R.id.ratingBarInfoParcours);
        btnModiff = (Button) findViewById(R.id.btnModifCritique);
        rbModifCritique = (RatingBar) findViewById(R.id.ratingBarModifCritique);

        SimpleDateFormat format1 = new SimpleDateFormat("yyyy-MM-dd", Locale.CANADA);
        String formatted = format1.format(infoParcoursParam.getM_dateOuverture().getTime());

        UtilisateurDataSource userDS = new UtilisateurDataSource(this);
        userDS.open();
       // Utilisateur user = userDS.getUtilisateur(infoParcoursParam.getM_usagerOuv());
        userDS.close();

        CritiqueDataSource critiqueDS = new CritiqueDataSource(this);
        critiqueDS.open();
        ArrayList<Critique> lstCritique;
        lstCritique = critiqueDS.getCritiqueByUser(idConnect);
        critiqueDS.close();


        for(Critique obj: lstCritique)
        {
            if(obj.getM_idParcours() == infoParcoursParam.getM_idParcours())
            {
                maCritique = obj;
            }
        }

        this.txtNomParcours.setText(infoParcoursParam.toString());
        this.txtDateOuverture.setText("Ouverture : " + formatted);
        this.txtCouleur.setText(infoParcoursParam.getM_couleurPrise().toString());
        //this.txtNomOuvreur.setText(user.getM_prenom() + " " + user.getM_nom());
        this.rbParcours.setRating(maCritique.getM_nbEtoile());

        btnModiff.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                /*maCritique.setM_nbEtoile(rbModifCritique.getRating());

                CritiqueDataSource critDS = new CritiqueDataSource(v.getContext());
                critDS.open();
                critDS.update(maCritique);
                critDS.close();
*/
                Toast.makeText(v.getContext(), "Critique mise à jour !", Toast.LENGTH_LONG).show();
            }
        });


    }
}

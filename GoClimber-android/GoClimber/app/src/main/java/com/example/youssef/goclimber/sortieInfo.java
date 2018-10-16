package com.example.youssef.goclimber;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.youssef.goclimber.data.Classes.DemandePartenaire;

import java.text.SimpleDateFormat;

public class sortieInfo extends Activity {
    private TextView txtType, txtAdresse, txtDate, txtCommentaire;
    private DemandePartenaire demandeParam;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sortie_info);
        txtType = (TextView) findViewById(R.id.txtSortieType);
        txtAdresse = (TextView) findViewById(R.id.txtSortieLieu);
        txtDate = (TextView) findViewById(R.id.txtSortieDate);
        txtCommentaire = (TextView) findViewById(R.id.txtSortieCommentaire);

        Bundle bundle = getIntent().getExtras();
        demandeParam = (DemandePartenaire) bundle.get("demande");

        txtType.setText(demandeParam.getM_typeParcours());
        txtAdresse.setText(demandeParam.getM_adresse());
        txtCommentaire.setText(demandeParam.getM_commentaire());
        String spdf =  new SimpleDateFormat("yyyy-MM-dd").format(demandeParam.getM_dateTime().getInstance().getTime());
        txtDate.setText(spdf);
    }

    public void btnPlanClick (View v) {
        Intent i = new Intent(this, monPlan.class);
        startActivity(i);
    }
}

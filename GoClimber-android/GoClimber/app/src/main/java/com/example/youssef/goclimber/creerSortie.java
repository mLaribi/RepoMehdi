package com.example.youssef.goclimber;


import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.Toast;

import java.sql.Date;
import java.text.SimpleDateFormat;


public class creerSortie extends AppCompatActivity implements Spinner.OnItemSelectedListener{

    private String[] arrType = {"Bloc", "Voie"};


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_creer_sortie);

        Spinner cbType = (Spinner) this.findViewById(R.id.cbType);
        cbType.setOnItemSelectedListener(this);

        cbType.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, arrType));

    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        Spinner sp = (Spinner) findViewById(R.id.cbType);
        Toast.makeText(this, sp.getSelectedItem().toString(), Toast.LENGTH_LONG).show();
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    public void btnEnvoyerClick(View v) {
        DatePicker dp = (DatePicker) findViewById(R.id.datePicker);
        SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy");
        int year = dp.getYear() - 1900; //LOL pas eu le choix
        int month = dp.getMonth();
        int day = dp.getDayOfMonth();
        String formatedDate = sdf.format(new Date(year, month, day));
        Toast.makeText(this, formatedDate, Toast.LENGTH_LONG).show();
    }


}



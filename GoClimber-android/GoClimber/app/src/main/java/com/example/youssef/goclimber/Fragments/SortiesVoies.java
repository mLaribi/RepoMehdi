package com.example.youssef.goclimber.Fragments;

import android.content.Intent;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.data.Classes.DemandePartenaire;
import com.example.youssef.goclimber.data.DemandeDataSource;
import com.example.youssef.goclimber.sortieInfo;

import java.lang.reflect.Array;
import java.util.ArrayList;

public class SortiesVoies extends Fragment {

    private ListView lstView;
    private ArrayList<DemandePartenaire> lstDemandeVoie;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_sorties_voies, container, false);
        this.lstView = (ListView) maView.findViewById(R.id.listViewSortieVoie);
        DemandeDataSource demandeDS = new DemandeDataSource(getContext());
        demandeDS.open();
        lstDemandeVoie = demandeDS.getAllDemandesVoie();
        demandeDS.close();

        lstView.setAdapter(new ArrayAdapter<DemandePartenaire>(getActivity(), android.R.layout.simple_list_item_1, lstDemandeVoie));
        lstView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent i = new Intent(getActivity(), sortieInfo.class);
                i.putExtra("demande", lstDemandeVoie.get(position));
                startActivity(i);
            }
        });
        return maView;
    }
}

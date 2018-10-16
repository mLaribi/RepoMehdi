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

import com.example.youssef.goclimber.FicheDeParcours;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.data.Classes.DemandePartenaire;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.DemandeDataSource;
import com.example.youssef.goclimber.sortieInfo;

import java.util.ArrayList;

public class SortiesBloc extends Fragment {
    private ArrayList<DemandePartenaire> lstDemandeBloc;
    private ListView lstView;
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_sorties_bloc, container, false);
        this.lstView = (ListView) maView.findViewById(R.id.listViewSortieBlocs);
        DemandeDataSource demandeDS = new DemandeDataSource(getContext());
        demandeDS.open();
        lstDemandeBloc = demandeDS.getAllDemandesBloc();
        demandeDS.close();

        lstView.setAdapter(new ArrayAdapter<DemandePartenaire>(getActivity(), android.R.layout.simple_list_item_1, lstDemandeBloc));
        lstView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent i = new Intent(getActivity(), sortieInfo.class);
                i.putExtra("demande", lstDemandeBloc.get(position));
                startActivity(i);
            }
        });
        return maView;
    }
}

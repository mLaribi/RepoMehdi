package com.example.youssef.goclimber.Fragments;

import android.support.v4.app.Fragment;
import android.app.ListActivity;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.youssef.goclimber.R;

import java.util.zip.Inflater;

public class Notifications extends Fragment {

    private ListView lstNotifs;
    private String[] arrNotifs = {"Une nouvelle voie a été ajoutée | 17:30","Nouvelle Invitation a une sortie | 17:30",
                                    "Un de vos parcours a été modifié | Hier", "Vous êtes beau | Depuis toujours"};

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View maVue = inflater.inflate(R.layout.activity_notifications, container, false);


        this.lstNotifs = (ListView) maVue.findViewById(R.id.lstNotifs);
        lstNotifs.setAdapter(new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, arrNotifs));

        return maVue;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);

      //  getMenuInflater().inflate(R.menu.context, menu);

    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {

        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();

       switch (item.getItemId()){
           case R.id.mnu_accept:
               accepterNotif(info.position);
               break;
           case R.id.mnu_refuse:
               refuserNotif(info.position);
               break;
       }

        return false;
    }


    public void accepterNotif(int position){
        //Toast.makeText(this, arrNotifs[position] + "a été acceptée", Toast.LENGTH_LONG).show();
    }

    public void refuserNotif(int position){
       // Toast.makeText(this, arrNotifs[position] + "a été refusée", Toast.LENGTH_LONG).show();
    }

}

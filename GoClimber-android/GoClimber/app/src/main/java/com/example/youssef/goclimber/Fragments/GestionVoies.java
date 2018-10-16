package com.example.youssef.goclimber.Fragments;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.youssef.goclimber.AjoutParcours;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.Util.jsonParser;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;


public class GestionVoies extends Fragment implements View.OnLongClickListener{
    private ArrayList<Parcours> arrMesParcours;
    private ListView lstMesVoies;
    private Button btnNewVoie;
    private int idConnect;


    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_PARCOURS = "/parcours";
    private final static int CONNECTION_TIMEOUT = 5000;
    //private final static int PORT = 7080;

    private final String TAG = this.getClass().getSimpleName();

    private HttpURLConnection mHttpURLConnection = null;

    private ArrayList<Parcours> mListeParcours;

    private ArrayAdapter<Parcours> mAdapter;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View viewGestionVoie = inflater.inflate(R.layout.activity_gestion_voies, container, false);

        idConnect = getArguments().getInt("idConnecter");

        //if voie pas de nom
        lstMesVoies = (ListView) viewGestionVoie.findViewById(R.id.listViewVoies);
        btnNewVoie = (Button) viewGestionVoie.findViewById(R.id.btnNouveauParcours);

        /*ParcoursDataSource parcoursDS = new ParcoursDataSource(getContext());
        parcoursDS.open();
        arrMesParcours = parcoursDS.getAllByUser(idConnect);
        parcoursDS.close();*/


        //lstMesVoies.setAdapter(new ArrayAdapter<Parcours>(getActivity(), android.R.layout.simple_list_item_1, arrMesParcours));

        btnNewVoie.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(getActivity(), AjoutParcours.class);
                //i.putExtra("idConnecter", idConnect);
                i.putExtra("modeOuverture", "Ajout");
                startActivity(i);
            }
        });
        this.registerForContextMenu(lstMesVoies);
        return viewGestionVoie;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        getActivity().getMenuInflater().inflate(R.menu.menu_gestion_parcours, menu);
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        int index = info.position;

        Parcours p = mListeParcours.get(index);

        switch(item.getItemId()) {
            case R.id.delete:
                p.setM_estArchive(true);
                new PutArchiveParcoursTask().execute(p);
                break;
            case R.id.edit:
                Intent i = new Intent(getActivity(), AjoutParcours.class);
                i.putExtra("modeOuverture", "Modification");
                i.putExtra("parcoursModif", mListeParcours.get(info.position));
                startActivity(i);
                break;
        }

        return false;
    }

 /*   private void archiver(int position) {
        Parcours parcoursArchiver = arrMesParcours.get(position);
        parcoursArchiver.setM_estArchive(true);
        ParcoursDataSource parcoursDS = new ParcoursDataSource(getContext());
        parcoursDS.open();
        parcoursDS.update(parcoursArchiver);
        parcoursDS.close();
        Toast.makeText(getContext(), "Archiver avec succès", Toast.LENGTH_LONG).show();
    }*/


    @Override
    public boolean onLongClick(View v) {
        return false;
    }


    @Override
    public void onStart() {
        super.onStart();

        new DownloadsParcoursListTask().execute((Void) null);
    }

    class DownloadsParcoursListTask extends AsyncTask<Void, Void, ArrayList<Parcours>> {

        Exception mException;

        @Override
        protected ArrayList<Parcours> doInBackground(Void... params) {
            ArrayList<Parcours> listeParcours = null;

            try {
                URL url = new URL("http", WEB_SERVICE_URL, REST_PARCOURS);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);
                String body = readStream(httpURLConnection.getInputStream());

                Log.i(TAG, "Reçu (GET) : " + body);

                listeParcours = jsonParser.deserialiserJsonListeParcours(body);
            } catch (Exception e) {
                mException = e;
            } finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }

            return listeParcours;
        }

        private String readStream(InputStream in) {

            StringBuilder sb = new StringBuilder();

            try {

                //Lecture du flux de données
                BufferedReader reader = new BufferedReader(new InputStreamReader(in,"UTF-8"));

                String nextLine = "";
                while ((nextLine = reader.readLine()) != null) {
                    sb.append(nextLine);
                }
            } catch (IOException e) {
                mException = e;
            }


            return sb.toString();
        }

        @Override
        protected void onPostExecute(ArrayList<Parcours> parcourses) {
            mListeParcours = new ArrayList<Parcours>();
            if(mException == null && parcourses != null){
                for (Parcours p : parcourses){
                    if(!p.getM_estArchive()){
                        mListeParcours.add(p);
                    }
                }
                mAdapter = new ArrayAdapter<Parcours>(getContext(), android.R.layout.simple_list_item_1, mListeParcours);
                lstMesVoies.setAdapter(mAdapter);
                mAdapter.notifyDataSetChanged();

            } else {
                Log.e(TAG, "Erreur lors de la récupération des historiques de réussite (GET)", mException);
                Toast.makeText(getContext(), "Erreur de communication", Toast.LENGTH_SHORT).show();
            }
        }
    }


    private class PutArchiveParcoursTask extends AsyncTask<Parcours, Void, Void>{
        Exception mException;

        @Override
        protected Void doInBackground(Parcours... params) {
            OutputStreamWriter osw = null;

            try {
                Parcours p = params[0];

                URL url = new URL ("http", WEB_SERVICE_URL, REST_PARCOURS + "/" + p.getM_idParcours());

                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();

                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);

                //Méthode
                httpURLConnection.setRequestMethod("PUT");

                httpURLConnection.setDoOutput(true);
                httpURLConnection.setRequestProperty("Content-Type", "application/json");
                httpURLConnection.setRequestProperty("Accept", "application/json");

                JSONObject json = jsonParser.serialiserJsonParcours(p);

                osw = new OutputStreamWriter(httpURLConnection.getOutputStream(),"UTF-8");
                osw.write(json.toString());
                osw.flush();
                osw.close();
                Log.i(TAG, "Put terminé avec succès : " + httpURLConnection.getResponseCode());

            } catch (Exception e) {
                mException = e;
            } finally {
                if (osw != null) {
                    try {
                        osw.flush();
                        osw.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }

                }

                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }

            }
            return null;
        }


        @Override
        protected void onPostExecute(Void aVoid) {
            if(mException == null)
            {
                Toast.makeText(getContext(), "Archivage réussi!", Toast.LENGTH_SHORT).show();

                new DownloadsParcoursListTask().execute((Void) null);
            }else {
                Log.e(TAG, "Erreur lors de l'archivage", mException);
                Toast.makeText(getContext(), "Erreur de la communication", Toast.LENGTH_SHORT).show();
            }
        }
    }
}

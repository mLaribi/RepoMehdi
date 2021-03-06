package com.example.youssef.goclimber.Fragments;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.FicheDeParcours;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.CritiqueDataSource;
import com.example.youssef.goclimber.Util.jsonParser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class ParcoursDispoVoie extends Fragment{

    private ListView lstView;
    private ArrayList<Parcours> vectParcoursDispoVoie;
    private ArrayList<Parcours> vectParcoursTrier = new ArrayList<>();
    private ArrayList<Critique> vectCritique;
    private TextView txtTitre;
    private String StrIdConnect;
    private int idConnect;

    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_PARCOURS = "/parcours";
    private final static int CONNECTION_TIMEOUT = 5000;

    private final String TAG = this.getClass().getSimpleName();

    private HttpURLConnection mHttpURLConnection = null;

    private ArrayList<Parcours> mListeVoie;

    private ArrayAdapter<Parcours> mAdapter;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_parcours_dispo_bloc, container, false);
        this.txtTitre = (TextView) maView.findViewById(R.id.txtParcoursDispo);
        txtTitre.setText("Voies Disponibles");
        this.lstView = (ListView) maView.findViewById(R.id.lstParcoursDispo);
       /* ParcoursDataSource mesParcoursDS = new ParcoursDataSource(getContext());
        mesParcoursDS.open();
        vectParcoursDispoVoie = mesParcoursDS.getAllVoies();
        mesParcoursDS.close();*/


       // StrIdConnect = container.getTag().toString();
       // idConnect = Integer.parseInt(StrIdConnect);

      /*  CritiqueDataSource critiqueDS = new CritiqueDataSource(getContext());
        critiqueDS.open();
        vectCritique = critiqueDS.getCritiqueByUser(idConnect);
        critiqueDS.close();*/

        boolean trouvee = false;
        //On retire les voie déjà réussie.
       /* for(Parcours obj: vectParcoursDispoVoie){
            for(Critique objCritique: vectCritique) {
                if(obj.getM_idParcours() == objCritique.getM_idParcours()) {
                    trouvee = true;
                }
            }
            if(!trouvee && !obj.getM_estArchive()) {
                vectParcoursTrier.add(obj);
            }
            else {
                trouvee = false;
            }
        }*/

        lstView.setAdapter(new ArrayAdapter<Parcours>(getActivity(), android.R.layout.simple_list_item_1, vectParcoursTrier));
        lstView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Parcours value = (Parcours) lstView.getItemAtPosition(position);
                Intent i = new Intent(getActivity(), FicheDeParcours.class);
                i.putExtra("ParcoursChoisi", value);
                i.putExtra("TypeParcours", "Voie");
                //i.putExtra("idConnect", idConnect);
                startActivity(i);
            }
        });


        return maView;
    }

    @Override
    public void onStart() {
        super.onStart();
        //Chargement asynchrone des Voies
        new DownloadListParcours().execute((Void) null);

    }

    class DownloadListParcours extends AsyncTask<Void, Void, ArrayList<Parcours>> {
        Exception mException;


        @Override
        protected ArrayList<Parcours> doInBackground(Void... params) {

            ArrayList<Parcours> listParcours = null;

            try {
                URL url = new URL("http", WEB_SERVICE_URL, REST_PARCOURS);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);
                String body = readStream(httpURLConnection.getInputStream());

                Log.i(TAG, "Reçu (GET) : " + body);

                listParcours = jsonParser.deserialiserJsonListeParcours(body);


            } catch (Exception e) {
                mException = e;
            } finally {
                if(mHttpURLConnection != null){
                    mHttpURLConnection.disconnect();
                }
            }

            return listParcours;
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
            mListeVoie = new ArrayList<Parcours>();
            if(mException == null && parcourses != null) {
                for (Parcours p : parcourses){
                    if(p.getM_typeVoie().equals("Voie")){
                        mListeVoie.add(p);
                    }
                }
                mAdapter = new ArrayAdapter<Parcours>(
                        getContext(), android.R.layout.simple_list_item_1, mListeVoie);
                lstView.setAdapter(mAdapter);
                mAdapter.notifyDataSetChanged();
        } else {

            Log.e(TAG, "Erreur lors de la récupération des Voies (GET)", mException);
            Toast.makeText(getContext(), "Erreur de communication", Toast.LENGTH_SHORT).show();
        }
        }

    }

}

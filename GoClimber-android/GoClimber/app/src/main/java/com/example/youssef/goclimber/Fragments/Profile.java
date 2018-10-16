package com.example.youssef.goclimber.Fragments;


import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.InfoParcours;
import com.example.youssef.goclimber.R;
import com.example.youssef.goclimber.Util.Utilitaire;
import com.example.youssef.goclimber.data.Classes.Critique;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.Classes.Utilisateur;
import com.example.youssef.goclimber.data.CritiqueDataSource;
import com.example.youssef.goclimber.data.UtilisateurDataSource;
import com.example.youssef.goclimber.Util.jsonParser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class Profile extends Fragment {

    private ArrayList<Critique> vectCritiqueDS;
    private ArrayList<Parcours> vectParcoursParCritique = new ArrayList<>();
    private ListView lstHistorique;
    private TextView txtNom;
    private TextView txtPrenom;
    private Utilisateur usagerConnect;


    //Accès a GAE local <a partir d'un émulateur
    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_HISTORIQUE = "/usagers/" + Utilitaire.user.getM_idUtilisateur() + "/historique";
    private final static int CONNECTION_TIMEOUT = 5000;

    private final String TAG = this.getClass().getSimpleName();

    private HttpURLConnection mHttpURLConnection = null;

    private ArrayList<Parcours> mListeParcours;

    private ArrayAdapter<Parcours> mAdapter;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        //final int idConnecter = getArguments().getInt("idConnecter");
        /*UtilisateurDataSource userDS = new UtilisateurDataSource(getContext());
        userDS.open();
        //usagerConnect = userDS.getUtilisateur(idConnecter);
        userDS.close();*/

        View maView = inflater.inflate(R.layout.activity_profile, container, false);
       /* CritiqueDataSource mesCritiquesDS = new CritiqueDataSource(getContext());
        mesCritiquesDS.open();
        vectCritiqueDS = mesCritiquesDS.getCritiqueByUser(usagerConnect.getM_idUtilisateur());
        mesCritiquesDS.close();*/


       /* ParcoursDataSource mesParcoursDS = new ParcoursDataSource(getContext());
        mesParcoursDS.open();
        for(Critique obj: vectCritiqueDS)
        {
            Parcours parc = mesParcoursDS.getParcours(obj.getM_idParcours());
            vectParcoursParCritique.add(parc);
        }
        mesParcoursDS.close();
*/
        this.txtNom = (TextView) maView.findViewById(R.id.txtNomFamille);
        this.txtPrenom = (TextView) maView.findViewById(R.id.txtPrenom);
        txtNom.setText(Utilitaire.user.getM_nom());
        txtPrenom.setText(Utilitaire.user.getM_prenom());

        this.lstHistorique = (ListView) maView.findViewById(R.id.lstHistorique);
        lstHistorique.setAdapter(new ArrayAdapter<Parcours>(getActivity(), android.R.layout.simple_list_item_1, vectParcoursParCritique));
        lstHistorique.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Parcours value = (Parcours) lstHistorique.getItemAtPosition(position);
                Intent i = new Intent(getActivity(), InfoParcours.class);
                //i.putExtra("ParcoursChoisi", value);
                //i.putExtra("idConnect", idConnecter);
                startActivity(i);
            }
        });

        return maView;
    }

    @Override
    public void onStart() {
        super.onStart();
        //Chargement de l'historique
        new DownloadsHistoriqueListTask().execute((Void) null);
    }

    class DownloadsHistoriqueListTask extends AsyncTask<Void, Void, ArrayList<Parcours>>{

        Exception mException;

        @Override
        protected ArrayList<Parcours> doInBackground(Void... params) {
            ArrayList<Parcours> listeParcours = null;

            try {
                URL url = new URL("http", WEB_SERVICE_URL, REST_HISTORIQUE);
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
            if(mException == null && parcourses != null){
                mListeParcours = parcourses;
                mAdapter = new ArrayAdapter<Parcours>(getContext(), android.R.layout.simple_list_item_1, mListeParcours);
                lstHistorique.setAdapter(mAdapter);
                mAdapter.notifyDataSetChanged();

            } else {
                Log.e(TAG, "Erreur lors de la récupération des historiques de réussite (GET)", mException);
                Toast.makeText(getContext(), "Erreur de communication", Toast.LENGTH_SHORT).show();
            }
        }
    }

}

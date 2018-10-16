package com.example.youssef.goclimber;

import android.app.DialogFragment;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.youssef.goclimber.Fragments.DatePickerFragment;
import com.example.youssef.goclimber.data.Classes.Couleur;
import com.example.youssef.goclimber.data.Classes.Difficulte;
import com.example.youssef.goclimber.data.Classes.Gym;
import com.example.youssef.goclimber.data.Classes.Parcours;
import com.example.youssef.goclimber.data.DifficulteDataSource;
import com.example.youssef.goclimber.Util.jsonParser;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Locale;


public class AjoutParcours extends AppCompatActivity implements Spinner.OnItemSelectedListener {

    private TextView txtDate;
    private Spinner cbType, cbDiff, cbCouleur, cbGym;
    private ArrayList<Difficulte> arrDiffBloc;
    private ArrayList<Difficulte> arrDiffVoies;
    private String[] styleParcours = {"Voie", "Bloc"};
    private String typeSelect = "Bloc";
    private String typeAjout = "Voie";
    private TextView titre;
    private Parcours parcoursModif;

    private EditText txtNom;
    private ImageButton mBouton;
    private DatePicker dpDate;
    private Button btnAjout;
    private int idConnect;
    private String modeOuverture;


    //Accès a GAE local
    private final static String WEB_SERVICE_URL = "tp4-ws-ml-yo.appspot.com";
    private final static String REST_GYM = "/gym";
    private final static String REST_PARCOURSAJ = "/gym/5659313586569216/parcours";
    private final static int CONNECTION_TIMEOUT = 5000;
    private final String TAG = this.getClass().getSimpleName();
    private HttpURLConnection mHttpURLConnection = null;

    private ArrayList<Gym> mLstGym;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ajout_parcours);
        Bundle bundle = getIntent().getExtras();
        //idConnect = bundle.getInt("idConnecter");
        modeOuverture = bundle.getString("modeOuverture");
        txtDate = (TextView) this.findViewById(R.id.txtDate);
        cbDiff = (Spinner) this.findViewById(R.id.spnDiff);
        cbType = (Spinner) this.findViewById(R.id.spnType);
        cbCouleur = (Spinner) this.findViewById(R.id.spnCouleur);
        cbGym = (Spinner) this.findViewById(R.id.spnGym);
        btnAjout = (Button) this.findViewById(R.id.btnAjouterParcours);
        txtNom = (EditText) this.findViewById(R.id.txtNomParcours);
        titre = (TextView) this.findViewById(R.id.lblTitreAjout);
        mBouton = (ImageButton) findViewById(R.id.btnDate);

        DifficulteDataSource diffDS = new DifficulteDataSource(this);
        diffDS.open();
        arrDiffBloc = diffDS.getDiffBloc();
        arrDiffVoies = diffDS.getDiffVoie();
        diffDS.close();

        cbType.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, styleParcours));
        cbCouleur.setAdapter(new ArrayAdapter<Couleur>(this, android.R.layout.simple_spinner_item, Couleur.values()));

        cbType.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                typeSelect = cbType.getItemAtPosition(position).toString();

                if (typeSelect.equals("Bloc")) {
                    cbDiff.setAdapter(new ArrayAdapter<Difficulte>(getApplicationContext(), android.R.layout.simple_spinner_item, arrDiffBloc));
                    txtNom.setVisibility(View.VISIBLE);
                    typeAjout = "Bloc";
                } else {
                    cbDiff.setAdapter(new ArrayAdapter<Difficulte>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item, arrDiffVoies));
                    txtNom.setVisibility(View.GONE);
                    typeAjout = "Voie";
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        cbDiff.setAdapter(new ArrayAdapter<Difficulte>(this, android.R.layout.simple_spinner_dropdown_item, arrDiffVoies));

        mBouton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDatePickerDialog();
            }
        });

        btnAjout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                btnAjoutClick(v);
                if (typeSelect.equals("Bloc")) {
                    txtNom.setText("");
                }
                cbDiff.setSelection(0);
                cbCouleur.setSelection(0);
                txtDate.setText("");
            }
        });

        if (modeOuverture.equals("Modification")) {
            parcoursModif = (Parcours) bundle.get("parcoursModif");
            titre.setText("Modifier un parcours");
            btnAjout.setText("Modifier");
            cbType.setEnabled(false);
            cbType.setClickable(false);
            mBouton.setEnabled(false);
            mBouton.setClickable(false);
            if (parcoursModif.getM_typeVoie().equals("Bloc")) {
                txtNom.setVisibility(View.VISIBLE);
                cbType.setSelection(1);
                txtNom.setText(parcoursModif.getM_nomParcours());
                int indexDiff = arrDiffBloc.indexOf(parcoursModif.getM_difficulte());
                int indexCouleur = Couleur.valueOf(parcoursModif.getM_couleurPrise().toString()).ordinal();
                cbDiff.setSelection(indexDiff);
                cbCouleur.setSelection(indexCouleur);
            } else {
                txtNom.setVisibility(View.GONE);
                cbType.setSelection(0);
                int indexDiff = arrDiffVoies.indexOf(parcoursModif.getM_difficulte());
                int indexCouleur = Couleur.valueOf(parcoursModif.getM_couleurPrise().toString()).ordinal();
                cbDiff.setSelection(indexDiff);
                cbCouleur.setSelection(indexCouleur);
            }

        } else {
            titre.setText("Ajouter un parcours");
            btnAjout.setText("Ajout");
            cbType.setEnabled(true);
            cbType.setClickable(true);
            mBouton.setEnabled(true);
            mBouton.setClickable(true);

        }
    }


    public void showDatePickerDialog() {
        DialogFragment dialogFragment = new DatePickerFragment();
        dialogFragment.show(getFragmentManager(), "Date Picker");

    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }

    @Override
    protected void onStart() {
        super.onStart();

        new DownloadGym().execute((Void) null);
    }

    public void btnAjoutClick(View v) {
        String nomParAj = " ";
        if (typeSelect.equals("Bloc")) {
            nomParAj = this.txtNom.getText().toString();
        }
        String diff = this.cbDiff.getSelectedItem().toString();
        String couleur = this.cbCouleur.getSelectedItem().toString();
        int couleurInd = Couleur.valueOf(couleur).ordinal();
        String gym = this.cbGym.getSelectedItem().toString();
        long idGym = 5659313586569216L;
        for (Gym g : mLstGym) {
            if (g.getM_nomGym().equals(gym)) {
                idGym = g.getM_idGym();
            }
        }

        java.util.Date maDateSql;
        SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd", Locale.CANADA);
        Calendar cal = Calendar.getInstance();
        String strDate = txtDate.getText().toString();
        Couleur cl = Couleur.values()[couleurInd];
        long idUsager = 5659313586569216L;
        boolean boolVar = false;
        try {
            maDateSql = new java.util.Date(formatter.parse(strDate).getTime());
            cal.setTime(maDateSql);

            Parcours pAjout = new Parcours(Parcours.ID_NON_DEFINI, nomParAj, typeSelect, diff, cl, maDateSql, idUsager, idGym, boolVar);

            new PostNewParcoursTask().execute(pAjout);

        } catch (Exception e) {
            e.printStackTrace();
        }


        if (modeOuverture.equals("Ajout")) {
            formatter = new SimpleDateFormat("yyyy-MM-dd", Locale.CANADA);
            cal = Calendar.getInstance();


            try {
                maDateSql = new java.sql.Date(formatter.parse(strDate).getTime());
                cal.setTime(maDateSql);

            } catch (ParseException e) {
                e.printStackTrace();
            }

            Parcours nouveauParcours;
            //si bloc
            if (typeSelect.equals("Bloc")) {
                // nouveauParcours  = new Parcours(5,txtNom.getText().toString(), typeSelect, cbDiff.getSelectedItem().toString(), (Couleur) cbCouleur.getSelectedItem(), cal, idConnect,false);
            } else {
                // nouveauParcours = new Parcours(5," ", typeSelect, cbDiff.getSelectedItem().toString(), (Couleur) cbCouleur.getSelectedItem(), cal, idConnect, false);
            }

            /*ParcoursDataSource parcoursDS = new ParcoursDataSource(this);
            parcoursDS.open();
            parcoursDS.insert(nouveauParcours);
            parcoursDS.close();
            Toast.makeText(this, "Parcours ajouté", Toast.LENGTH_LONG).show();
            Intent i = new Intent(this, MainActivity.class);
            i.putExtra("idConnecter", idConnect);
            startActivity(i);
        }else {
            parcoursModif.setM_couleurPrise((Couleur) cbCouleur.getSelectedItem());
            parcoursModif.setM_difficulte(cbDiff.getSelectedItem().toString());
            parcoursModif.setM_nomParcours(txtNom.getText().toString());
            ParcoursDataSource parcoursDS = new ParcoursDataSource(this);
            parcoursDS.open();
            parcoursDS.update(parcoursModif);
            parcoursDS.close();
            Toast.makeText(this, "Parcours modifier", Toast.LENGTH_LONG).show();
            Intent i = new Intent(this, MainActivity.class);
            i.putExtra("idConnecter", idConnect);
            startActivity(i);
        }*/

        }
    }

    class DownloadGym extends AsyncTask<Void, Void, ArrayList<Gym>> {
        Exception mException;


        @Override
        protected void onPreExecute() {

        }


        @Override
        protected ArrayList<Gym> doInBackground(Void... params) {
            ArrayList<Gym> lstGym = null;

            try {

                URL url = new URL("http", WEB_SERVICE_URL, REST_GYM);

                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();

                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);

                String body = readStream(httpURLConnection.getInputStream());

                Log.i(TAG, "Reçu (GET) : " + body);

                lstGym = jsonParser.deserialiserJsonListeGym(body);

            } catch (Exception e) {
                mException = e;
            } finally {
                if (mHttpURLConnection != null) {
                    mHttpURLConnection.disconnect();
                }
            }
            return lstGym;
        }

        /**
         * Méthode permettant de lire un InputStream
         *
         * @param in InputStream
         * @return String une chaîne de caractères
         */
        private String readStream(InputStream in) {

            StringBuilder sb = new StringBuilder();

            try {

                //Lecture du flux de données
                BufferedReader reader = new BufferedReader(new InputStreamReader(in, "UTF-8"));

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
        protected void onPostExecute(ArrayList<Gym> gyms) {
            if (mException == null && gyms != null) {
                mLstGym = gyms;
                ArrayAdapter<Gym> spinnGym = new ArrayAdapter<Gym>(AjoutParcours.this, android.R.layout.simple_spinner_item, mLstGym);
                cbGym.setAdapter(spinnGym);

                spinnGym.notifyDataSetChanged();
            } else {
                Log.e(TAG, "Erreur lors de la récupération des gym (GET)", mException);
                Toast.makeText(AjoutParcours.this, "Erreur de communication", Toast.LENGTH_SHORT).show();
            }
        }
    }


    private class PostNewParcoursTask extends AsyncTask<Parcours, Void, Void> {
        Exception mException;

        @Override
        protected Void doInBackground(Parcours... params) {

            OutputStreamWriter osw = null;

            try {

                Parcours p = params[0];

                URL url = new URL("http", WEB_SERVICE_URL, REST_PARCOURSAJ);

                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();

                httpURLConnection.setConnectTimeout(CONNECTION_TIMEOUT);

                //Méthode
                httpURLConnection.setRequestMethod("POST");

                httpURLConnection.setDoOutput(true);
                httpURLConnection.setRequestProperty("Content-Type", "application/json");
                httpURLConnection.setRequestProperty("Accept", "application/json");

                //Sérialisation de l'objet en JSON
                JSONObject json = jsonParser.serialiserJsonParcours(p);

                osw = new OutputStreamWriter(httpURLConnection.getOutputStream(), "UTF-8");
                osw.write(json.toString());
                osw.flush();
                osw.close();


                Log.i(TAG, "Post termniné avec succès : " + httpURLConnection.getResponseCode());

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
            if (mException == null) {
                Toast.makeText(AjoutParcours.this, "Ajout s'est fait avec succès", Toast.LENGTH_SHORT).show();
            } else {
                Log.e(TAG, "Erreur lors de l'ajout du parcours (POST)", mException);
                Toast.makeText(AjoutParcours.this, "Erreur de communication", Toast.LENGTH_SHORT).show();
            }
        }
    }
}

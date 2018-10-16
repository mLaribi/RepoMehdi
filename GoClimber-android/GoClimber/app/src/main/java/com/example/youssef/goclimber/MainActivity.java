package com.example.youssef.goclimber;

import android.app.ActionBar;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import com.example.youssef.goclimber.Fragments.GestionVoies;
import com.example.youssef.goclimber.Fragments.ModifProfile;
import com.example.youssef.goclimber.Fragments.Notifications;
import com.example.youssef.goclimber.Fragments.ParcoursDispo;
import com.example.youssef.goclimber.Fragments.ParcoursDispoBloc;
import com.example.youssef.goclimber.Fragments.Profile;
import com.example.youssef.goclimber.Fragments.classementFragment;
import com.example.youssef.goclimber.Fragments.statsFragment;
import com.example.youssef.goclimber.Util.Utilitaire;
import com.example.youssef.goclimber.data.Classes.Utilisateur;
import com.example.youssef.goclimber.data.UtilisateurDataSource;
//import com.example.youssef.goclimber.data.UtilisateurDataSource;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    private Toolbar mToolbar;
    private NavigationView mNavigationView;
    private DrawerLayout mDrawerLayout;
    private int idConnec;
    private Utilisateur usagerConnecter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mToolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(mToolbar);

        //Bundle bundle = getIntent().getExtras();
        //idConnec = bundle.getInt("idConnecter");

        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, mDrawerLayout,mToolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);

        mDrawerLayout.setDrawerListener(toggle);

        toggle.syncState();

        mNavigationView = (NavigationView) findViewById(R.id.nav_view);
        mNavigationView.setNavigationItemSelectedListener(this);

        //Bundle bundleSend = new Bundle();
        Profile myProfile = new Profile();
        android.support.v4.app.FragmentTransaction fragmentTransaction;
        fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame, myProfile);
        //bundleSend.putInt("idConnecter", idConnec);
        //myProfile.setArguments(bundleSend);
        fragmentTransaction.commit();


//        UtilisateurDataSource userDS = new UtilisateurDataSource(this);
//        userDS.open();
//        usagerConnecter = userDS.getUtilisateur(idConnec);
//        userDS.close();
    }

    @Override
    protected void onResume() {
        super.onResume();
        setTitle("Bienvenue !");
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.mnu_centreEscalade) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        item.setChecked(true);
        mDrawerLayout.closeDrawers();
        setTitle(item.getTitle());
        selectItem(item.getItemId());
        return true;
    }

    private void selectItem(int id)
    {
        android.support.v4.app.FragmentTransaction fragmentTransaction;
        Bundle bundleSend = new Bundle();
        switch (id){
            case R.id.nav_profile:
                Profile monProfile = new Profile();
                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, monProfile);
                fragmentTransaction.commit();
                break;
            case R.id.nav_trouverParcours:
                ParcoursDispo mesParcours = new ParcoursDispo();
                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, mesParcours);
                fragmentTransaction.commit();
                break;
            case R.id.nav_modProfile:
                ModifProfile maModif = new ModifProfile();

                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, maModif);
                fragmentTransaction.commit();
                break;
            case R.id.nav_mesVoies:
                if(Utilitaire.user.getM_typeUtil().equals("Ouvreur")) {
                    GestionVoies maGestionVoie = new GestionVoies();
                    fragmentTransaction = getSupportFragmentManager().beginTransaction();
                    fragmentTransaction.replace(R.id.frame, maGestionVoie);
                    fragmentTransaction.commit();
                    break;
                }else
                {
                    Toast.makeText(this, "Vous n'avez pas accès à cette section.",Toast.LENGTH_LONG).show();
                    break;
                }

            case R.id.nav_mesNotif:
                Notifications mesNotif = new Notifications();
                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, mesNotif);
                fragmentTransaction.commit();
                break;

            case R.id.nav_statistiques:
                statsFragment mesStats = new statsFragment();
                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, mesStats);
                fragmentTransaction.commit();
                break;

            case R.id.nav_classement:
                classementFragment monClassement = new classementFragment();
                fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.frame, monClassement);
                fragmentTransaction.commit();
            case R.id.nav_deco:
                Utilitaire.user = null;
                Intent i = new Intent(this, Login.class);
                startActivity(i);
                break;
            case R.id.nav_CreeSorties:
                Intent in = new Intent(this, creerSortie.class);
                startActivity(in);
                break;
            case R.id.nav_sorties:
                Intent iSortie = new Intent(this, MesSorties.class);
                startActivity(iSortie);
                break;
        }
    }
}
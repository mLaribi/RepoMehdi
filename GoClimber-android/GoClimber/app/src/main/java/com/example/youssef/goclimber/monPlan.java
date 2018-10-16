package com.example.youssef.goclimber;

import android.Manifest;
import android.content.pm.PackageManager;
import android.location.Location;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.FragmentActivity;
import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.LocationListener;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;

import java.text.DateFormat;

public class monPlan extends FragmentActivity implements OnMapReadyCallback, GoogleApiClient.ConnectionCallbacks,
        GoogleApiClient.OnConnectionFailedListener,
        LocationListener {

    // Coordonnées initiales : Haute-ville de Québec.
    private final static LatLng QUEBEC_HAUTE_VILLE = new LatLng(46.813395, -71.215954);
    //Code de requête pour la demande de permission pour la géolocalisation.
    private static int REQUEST_LOCATION = 123;
    private GoogleMap mMap = null;
    // Permet d'accéder au service Google Play.

    private GoogleApiClient mGoogleApiClient;

    // Dernière position obtenue.
    private Location mLastLocation = null;

    // Objet servant à spécifier la qualité désirée de la localisation.
    private LocationRequest mLocationRequest;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mon_plan);

        // On vérifie si l'application possède les perssions requises pour afficher la localisation de l'utilisateur.
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION)
                != PackageManager.PERMISSION_GRANTED) {

            //Affichage du messsage demandant la permission à l'utilisateur.
            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                    REQUEST_LOCATION);
        }

        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);

        setupGoogleApiClient();
        createLocationRequest();
    }

    protected synchronized void setupGoogleApiClient() {
        mGoogleApiClient = new GoogleApiClient.Builder(this)
                .addConnectionCallbacks(this)
                .addOnConnectionFailedListener(this)
                .addApi(LocationServices.API)
                .build();
    }

    @Override
    protected void onStart() {
        // Connexion au service Google Play.
        mGoogleApiClient.connect();
        super.onStart();
    }

    @Override
    protected void onResume() {
        super.onResume();

        if (mGoogleApiClient.isConnected()) {
            this.startLocationUpdates();
        }
    }


    @Override
    protected void onStop() {
        // Déconnexion du service Google Play.
        mGoogleApiClient.disconnect();
        super.onStop();
    }

    @Override
    protected void onPause() {
        super.onPause();

        if (mGoogleApiClient.isConnected()) {
            this.stopLocationUpdates();
        }
    }

    protected void startLocationUpdates() {

        // On vérifie si l'application possède les perssions requises pour afficher la localisation de l'utilisateur.
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION)
                == PackageManager.PERMISSION_GRANTED) {
            LocationServices.FusedLocationApi.requestLocationUpdates(mGoogleApiClient, mLocationRequest, this);

        }

    }


    /**
     * Arrête les demandes de mises à jour de la localisation.
     */
    protected void stopLocationUpdates() {
        LocationServices.FusedLocationApi.removeLocationUpdates(mGoogleApiClient, this);
    }

    /**
     * Création et paramètrisation de la requête de localisation.
     */
    protected void createLocationRequest() {
        // Voir les indications :
        // @see http://developer.android.com/training/location/receive-location-updates.html
        mLocationRequest = LocationRequest.create();
        // Voir les constantes PRIORITY_XXXXX
        mLocationRequest.setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY);
        // Intervale minimal des mises à jour.
        // Des mises à jour trop fréquentes peuvent faire "flicker" le UI.
        mLocationRequest.setFastestInterval(5 * 1000);
        // Intervalle maximal pour les mises à jour de la position.
        mLocationRequest.setInterval(10 * 1000);
    }


    private void updateLocation() {
        if (mLastLocation != null) {
            // Centrage de la carte sur la position obtenue.
            mMap.moveCamera(CameraUpdateFactory.newLatLng(new LatLng(mLastLocation.getLatitude(), mLastLocation.getLongitude())));
        }
    }


    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;
        //Position initiale de la carte
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(QUEBEC_HAUTE_VILLE, 15));

        // On vérifie si l'application possède les perssions requises pour afficher la localisation de l'utilisateur.
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            // Permet d'afficher la position de l'utilisateur.
            mMap.setMyLocationEnabled(true);
        }
    }

    /* Implémentation de l'interface "GoogleApiClient.ConnectionCallbacks" */
    /* =================================================================== */
    @Override
    public void onConnected(Bundle bundle) {
        Log.d("MapsActivity", "GoogleApiClient.ConnectionCallbacks.onConnected");

        // On vérifie si l'application possède les perssions requises pour afficher la localisation de l'utilisateur.
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            mLastLocation = LocationServices.FusedLocationApi.getLastLocation(mGoogleApiClient);
            if (mLastLocation != null) {
                updateLocation();
                this.startLocationUpdates();
            }
        }

    }


    @Override
    public void onConnectionSuspended(int i) {
        Log.d("MapsActivity", "GoogleApiClient.ConnectionCallbacks.onConnectionSuspended");
    }


    /* Implémentation de l'interface "LocationListener" */
    /* ================================================ */
    @Override
    public void onLocationChanged(Location location) {
        mLastLocation = location;
        // Mise à jour du UI.
        updateLocation();
    }

    /**
     * Reçoit les résultats pour les demandes d'autorisation
     *
     * @param requestCode  int : Le code de demande passée en paramêtre de requestPermissions
     * @param permissions  String[] : Les résultats de reçus pour les autorisations correspondantes(PERMISSION_GRANTED ou PERMISSION_DENIED)
     * @param grantResults int[] : Les autorisations demandées
     */
    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        if (requestCode == REQUEST_LOCATION) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                //On obtien la position de l'utilisateur
                mMap.setMyLocationEnabled(true);

            } else {
                // Permission refusée or requête annulée
                Toast.makeText(this, "Impossible d'afficher la localisation.", Toast.LENGTH_SHORT).show();

            }
        }
    }

    @Override
    public void onConnectionFailed(ConnectionResult connectionResult) {

    }
}

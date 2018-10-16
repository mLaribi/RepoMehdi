package com.example.youssef.goclimber;

import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;

import com.example.youssef.goclimber.Adapter.SortiesTabsPagerAdapter;
import com.example.youssef.goclimber.Fragments.SortiesBloc;
import com.example.youssef.goclimber.Fragments.SortiesVoies;

public class MesSorties extends AppCompatActivity {


    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mes_sorties);

        //Affichage de la toolbar
        toolbar = (Toolbar) findViewById(R.id.toolbarSortie);
        //setSupportActionBar(toolbar);

        //Initialisation du viewPager et configuration du ViewPager
        viewPager = (ViewPager) findViewById(R.id.viewPagerSortie);
        setupViewPager(viewPager);

        //Initialisation du TabLayout
        tabLayout = (TabLayout) findViewById(R.id.tablayoutSortie);
        //Association du TabLayout au ViewPager.
        tabLayout.setupWithViewPager(viewPager);
    }

    private void setupViewPager(ViewPager viewPager) {
        SortiesTabsPagerAdapter adapter = new SortiesTabsPagerAdapter(getSupportFragmentManager());
        String[] tabs = getResources().getStringArray(R.array.tabsSorties);
        adapter.addFragment(new SortiesBloc(), tabs[0]);
        adapter.addFragment(new SortiesVoies(), tabs[1]);
        viewPager.setAdapter(adapter);
    }
}

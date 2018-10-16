package com.example.youssef.goclimber.Fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.youssef.goclimber.Adapter.TabsPagerAdapter;
import com.example.youssef.goclimber.R;


public class ParcoursDispo extends Fragment {

    private TabLayout tablayout;
    private ViewPager viewPager;
    private int idConnect;
    private String strIdConnect;



    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View maView = inflater.inflate(R.layout.activity_parcours_dispo, container, false);
        //idConnect = getArguments().getInt("idConnecter");
        //strIdConnect = Integer.toString(idConnect);
        viewPager =  (ViewPager) maView.findViewById(R.id.viewpager);
        setupViewPager(viewPager);
        tablayout = (TabLayout) maView.findViewById(R.id.tab_layout);
        tablayout.setupWithViewPager(viewPager);
        return maView;
    }

    private void setupViewPager(ViewPager viewPager) {
        viewPager.setTag(strIdConnect);
        TabsPagerAdapter adapter = new TabsPagerAdapter(getFragmentManager());
        String[] tabs = getResources().getStringArray(R.array.tabsType);
        adapter.addFragment(new ParcoursDispoBloc(), tabs[0]);
        adapter.addFragment(new ParcoursDispoVoie(), tabs[1]);
        viewPager.setAdapter(adapter);
    }

}

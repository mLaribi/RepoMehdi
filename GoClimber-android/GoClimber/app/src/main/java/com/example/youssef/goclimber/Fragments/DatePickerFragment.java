package com.example.youssef.goclimber.Fragments;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;
import android.widget.DatePicker;
import android.widget.TextView;

import com.example.youssef.goclimber.R;

import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Mehdi on 2016-02-26.
 */
public class DatePickerFragment extends DialogFragment implements DatePickerDialog.OnDateSetListener {
   final Calendar cal = Calendar.getInstance();


    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        return new DatePickerDialog(getActivity(), this, cal.get(Calendar.YEAR),cal.get(Calendar.MONTH),cal.get(Calendar.DAY_OF_MONTH));
    }

    @Override
    public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {


        cal.set(Calendar.YEAR, year);
        cal.set(Calendar.MONTH, monthOfYear);
        cal.set(Calendar.DAY_OF_MONTH, dayOfMonth);
        Date selectedDate = cal.getTime();

        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

        TextView txtDate = (TextView) getActivity().findViewById(R.id.txtDate);
        txtDate.setText(sdf.format(selectedDate));
    }


}

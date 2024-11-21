package com.example.myapplication;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.LinearLayout;

import com.google.android.material.bottomsheet.BottomSheetBehavior;
import com.google.android.material.bottomsheet.BottomSheetDialog;
import com.google.android.material.bottomsheet.BottomSheetDialogFragment;

public class CartSheetFragment extends BottomSheetDialogFragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_cart, container, false);
    }

    @Override
    public void onViewCreated(View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        // Find the vertical LinearLayout in the product_detail_layout
        LinearLayout cartItemsContainer = view.findViewById(R.id.cartItems);

        // Inflate and add 5 instances of cart_item_layout to the cartItemsContainer
        LayoutInflater inflater = LayoutInflater.from(getContext());
        for (int i = 0; i < 10; i++) {
            View cartItem = inflater.inflate(R.layout.cart_item_layout, cartItemsContainer, false);
            cartItemsContainer.addView(cartItem);
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        BottomSheetDialog dialog = (BottomSheetDialog) getDialog();
        if (dialog != null) {
            View bottomSheet = dialog.findViewById(com.google.android.material.R.id.design_bottom_sheet);
            if (bottomSheet != null) {
                // Set the bottom sheet's height to match the parent
                bottomSheet.getLayoutParams().height = WindowManager.LayoutParams.MATCH_PARENT;
                BottomSheetBehavior<View> behavior = BottomSheetBehavior.from(bottomSheet);
                behavior.setState(BottomSheetBehavior.STATE_EXPANDED);
            }
        }
    }
}

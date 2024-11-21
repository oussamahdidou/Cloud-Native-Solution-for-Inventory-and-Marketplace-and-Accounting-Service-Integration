package com.example.myapplication;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.GridLayout;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import com.bumptech.glide.Glide;
import com.example.myapplication.apicall.ApiClient;
import com.example.myapplication.models.CategoryItem;
import com.example.myapplication.models.ProductItem;
import com.example.myapplication.services.ApiService;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeFragment extends Fragment {
    private EditText editText;
    private LinearLayout linearLayout;
    private GridLayout gridLayout;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home, container, false);

        // Initialize layouts
        linearLayout = view.findViewById(R.id.categoriesLayout);
        gridLayout = view.findViewById(R.id.productsGridLayout);
        editText = view.findViewById(R.id.editTextText3);

        // Initialize the API service
        ApiService apiService = ApiClient.getRetrofitInstance().create(ApiService.class);

        // Fetch categories
        apiService.getCategories().enqueue(new Callback<List<CategoryItem>>() {
            @Override
            public void onResponse(Call<List<CategoryItem>> call, Response<List<CategoryItem>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    List<CategoryItem> categoryItems = response.body();
                    LayoutInflater inflater = getLayoutInflater();

                    for (CategoryItem item : categoryItems) {
                        View itemView = inflater.inflate(R.layout.category_layout, linearLayout, false);
                        ImageView imageView = itemView.findViewById(R.id.item_image);
                        TextView textView = itemView.findViewById(R.id.item_label);

                        // Load category image
                        Glide.with(getContext())
                                .load(item.getThumbnail())
                                .placeholder(R.mipmap.place_holder_image)
                                .error(R.mipmap.place_holder_image)
                                .into(imageView);

                        // Set category name
                        textView.setText(item.getName());

                        // Add the category view to the layout
                        linearLayout.addView(itemView);
                    }
                } else {
                    Log.e("API_ERROR", "Categories response unsuccessful or empty");
                }
            }

            @Override
            public void onFailure(Call<List<CategoryItem>> call, Throwable t) {
                Log.e("API_ERROR", "Failed to fetch categories: " + t.getMessage());
            }
        });

        // Fetch products
        apiService.getProducts().enqueue(new Callback<List<ProductItem>>() {
            @Override
            public void onResponse(Call<List<ProductItem>> call, Response<List<ProductItem>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    List<ProductItem> productItems = response.body();
                    LayoutInflater inflater = getLayoutInflater();

                    for (ProductItem product : productItems) {
                        View productItemView = inflater.inflate(R.layout.product_layout, gridLayout, false);

                        ImageView imageView = productItemView.findViewById(R.id.product_thumbnail);
                        TextView nameView = productItemView.findViewById(R.id.product_label);
                        TextView priceView = productItemView.findViewById(R.id.product_price);
                        TextView quantityView = productItemView.findViewById(R.id.product_quantity);

                        // Load product image
                        Glide.with(getContext())
                                .load(product.getThumbnail())
                                .placeholder(R.mipmap.place_holder_image)
                                .error(R.mipmap.place_holder_image)
                                .into(imageView);

                        // Set product details
                        nameView.setText(product.getName());
                        priceView.setText("Price: " + product.getPrice());
                        quantityView.setText("Quantity: " + product.getQuantity());

                        // Set onClickListener to show product details
                        productItemView.setOnClickListener(v -> {
                            ProductDetailSheetFragment bottomSheetFragment = new ProductDetailSheetFragment();
                            Bundle args = new Bundle();
                            args.putSerializable("product", product.getProductId()); // Pass product data
                            bottomSheetFragment.setArguments(args);
                            bottomSheetFragment.show(getParentFragmentManager(), bottomSheetFragment.getTag());
                        });

                        // Add the product view to the GridLayout
                        gridLayout.addView(productItemView);
                    }
                } else {
                    Log.e("API_ERROR", "Products response unsuccessful or empty");
                }
            }

            @Override
            public void onFailure(Call<List<ProductItem>> call, Throwable t) {
                Log.e("API_ERROR", "Failed to fetch products: " + t.getMessage());
            }
        });

        // Handle EditText actions
        editText.setOnEditorActionListener((v, actionId, event) -> {
            if (actionId == EditorInfo.IME_ACTION_DONE) {
                String inputText = editText.getText().toString();

                // Pass data to the TargetFragment
                Bundle bundle = new Bundle();
                bundle.putString("inputKey", inputText);

                Fragment targetFragment = new ProductListFragment();
                targetFragment.setArguments(bundle);

                // Navigate to TargetFragment
                requireActivity().getSupportFragmentManager().beginTransaction()
                        .replace(R.id.container, targetFragment)
                        .addToBackStack(null)
                        .commit();

                // Hide the keyboard
                InputMethodManager imm = (InputMethodManager) requireActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(editText.getWindowToken(), 0);

                return true;
            }
            return false;
        });

        return view;
    }
}

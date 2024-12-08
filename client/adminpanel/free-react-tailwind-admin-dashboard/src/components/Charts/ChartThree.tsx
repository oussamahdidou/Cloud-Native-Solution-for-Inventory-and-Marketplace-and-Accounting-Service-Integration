import { ApexOptions } from 'apexcharts';
import React, { useEffect, useState } from 'react';
import ReactApexChart from 'react-apexcharts';
import { GetProducts } from '../../services/productservice';

const ChartThree: React.FC = () => {
  const [products, setProducts] = useState<string[]>([]);
  const [quantities, setQuantities] = useState<number[]>([]);
  const [colors, setColors] = useState<string[]>([]); // Store colors for consistency

  useEffect(() => {
    const fetchData = async () => {
      try {
        const products = await GetProducts();
        const Quantities = products.map((item) => item.quantity);
        const productsnames = products.map((item) => item.name);

        // Generate consistent colors for each product
        const generatedColors = products.map(
          () => `#${Math.floor(Math.random() * 16777215).toString(16)}`,
        );

        setQuantities(Quantities);
        setProducts(productsnames);
        setColors(generatedColors); // Set generated colors
      } catch (error) {
        console.error('Error fetching stock progress', error);
      }
    };

    fetchData();
  }, []);

  const options: ApexOptions = {
    chart: {
      fontFamily: 'Satoshi, sans-serif',
      type: 'donut',
    },
    labels: products,
    colors: colors, // Use consistent colors for the chart
    legend: {
      show: false,
      position: 'bottom',
      formatter: (seriesName, opts) =>
        `${seriesName}: ${opts.w.globals.series[opts.seriesIndex]}`,
    },
    plotOptions: {
      pie: {
        donut: {
          size: '65%',
          background: 'transparent',
        },
      },
    },
    dataLabels: {
      enabled: false,
    },
    responsive: [
      {
        breakpoint: 2600,
        options: {
          chart: {
            width: 380,
          },
        },
      },
      {
        breakpoint: 640,
        options: {
          chart: {
            width: 200,
          },
        },
      },
    ],
  };

  return (
    <div className="sm:px-7.5 col-span-12 rounded-sm border border-stroke bg-white px-5 pb-5 pt-7.5 shadow-default dark:border-strokedark dark:bg-boxdark xl:col-span-5">
      <div className="mb-3 justify-between gap-4 sm:flex">
        <div>
          <h5 className="text-xl font-semibold text-black dark:text-white">
            Visitors Analytics
          </h5>
        </div>
      </div>

      <div className="mb-2">
        <div id="chartThree" className="mx-auto flex justify-center">
          <ReactApexChart options={options} series={quantities} type="donut" />
        </div>
      </div>

      <div className="-mx-8 flex flex-wrap items-center justify-center gap-y-3">
        {products.map((product, index) => (
          <div key={index} className="sm:w-1/2 w-full px-8">
            <div className="flex w-full items-center">
              <span
                className="mr-2 block h-3 w-full max-w-3 rounded-full"
                style={{ backgroundColor: colors[index] }} // Use consistent color for legend
              ></span>
              <p className="flex w-full justify-between text-sm font-medium text-black dark:text-white">
                <span>{product}</span>
                <span>{quantities[index]}</span>
              </p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ChartThree;

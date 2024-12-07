import { ApexOptions } from 'apexcharts';
import React, { useEffect, useState } from 'react';
import ReactApexChart from 'react-apexcharts';
import {
  EntriesOfTheweek,
  SortiesOfTheweek,
} from '../../services/dashboardservice';

const ChartTwo: React.FC = () => {
  const [sortieData, setSortieData] = useState<number[]>([]);
  const [entreeData, setEntreeData] = useState<number[]>([]);
  const [weeks, setWeeks] = useState<string[]>([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const sortieProgress = await SortiesOfTheweek();
        const entreeProgress = await EntriesOfTheweek();

        // Extracting the data and month (assuming month format is consistent with categories)
        const sortieQuantities = sortieProgress.map((item) => item.total);
        const entreeQuantities = entreeProgress.map((item) => item.total);
        const weeksdata = sortieProgress.map((item) => item.date.charAt(0)); // Assuming both responses have the same months
        console.log(weeksdata);
        setSortieData(sortieQuantities);
        setEntreeData(entreeQuantities);
        setWeeks(weeksdata);
      } catch (error) {
        console.error('Error fetching stock progress', error);
      }
    };

    fetchData();
  }, []);
  const options: ApexOptions = {
    colors: ['#3C50E0', '#80CAEE'],
    chart: {
      fontFamily: 'Satoshi, sans-serif',
      type: 'bar',
      height: 335,
      stacked: true,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
    },

    responsive: [
      {
        breakpoint: 1536,
        options: {
          plotOptions: {
            bar: {
              borderRadius: 0,
              columnWidth: '25%',
            },
          },
        },
      },
    ],
    plotOptions: {
      bar: {
        horizontal: false,
        borderRadius: 0,
        columnWidth: '25%',
        borderRadiusApplication: 'end',
        borderRadiusWhenStacked: 'last',
      },
    },
    dataLabels: {
      enabled: false,
    },

    xaxis: {
      categories: weeks,
    },
    legend: {
      position: 'top',
      horizontalAlign: 'left',
      fontFamily: 'Satoshi',
      fontWeight: 500,
      fontSize: '14px',

      markers: {
        radius: 99,
      },
    },
    fill: {
      opacity: 1,
    },
  };
  const series = [
    {
      name: 'Sortie Stock',
      data: sortieData,
    },
    {
      name: 'Entree Stock',
      data: entreeData,
    },
  ];
  return (
    <div className="col-span-12 rounded-sm border border-stroke bg-white p-7.5 shadow-default dark:border-strokedark dark:bg-boxdark xl:col-span-4">
      <div className="mb-4 justify-between gap-4 sm:flex">
        <div>
          <h4 className="text-xl font-semibold text-black dark:text-white">
            Profit this week
          </h4>
        </div>
        <div></div>
      </div>

      <div>
        <div id="chartTwo" className="-ml-5 -mb-9">
          <ReactApexChart
            options={options}
            series={series}
            type="bar"
            height={350}
          />
        </div>
      </div>
    </div>
  );
};

export default ChartTwo;

<!--
created:    20260422 / alphabeit
lastupdate: 20260429 / alphabeit
-->

<template>
  <section class="container">
    <div class="right-half">

      <section class="cards-wrapper cards-wrapper-smaller">
        <div class="card-grid-space" v-for="vehicleBody in vehicleBodys">
          <a class="card card-smaller" :class="vehicleBody.image"> 
            <div>
              <h1>{{ vehicleBody.name }}</h1>
              <p>{{ vehicleBody.price }} EUR</p>
            </div>
          </a>
        </div>
      </section>

      <section class="cards-wrapper cards-wrapper-smaller">
        <div class="card-grid-space" v-for="vehicleColor in vehicleColors">
          <a class="card card-smaller" :class="vehicleColor.name">
            <div>
              <h1>{{ vehicleColor.name }}</h1>
              <p>{{ vehicleColor.price }} EUR</p>
            </div>
          </a>
        </div>
      </section>

      <section class="cards-wrapper cards-wrapper-smaller">
        <div class="card-grid-space" v-for="wheel in wheels">
          <a class="card card-smaller" :class="wheel.image">
            <div>
              <h1>{{ wheel.name }} Wheel</h1>
              <p>{{ wheel.price }} EUR</p>
            </div>
          </a>
        </div>
      </section>

      <section class="cards-wrapper cards-wrapper-smaller">
        <div class="card-grid-space" v-for="engine in engines">
          <a class="card card-smaller" :class="engine.image">
            <div>
              <h1>{{ engine.name }} Engine</h1>
              <p>{{ engine.ps }} PS <br> {{ engine.price }} EUR</p>
            </div>
          </a>
        </div>
      </section>

    </div> <!-- class="right-half" -->
    
    <div class="left-half"> 
    </div> <!-- class="left-half" -->

  </section> <!-- class="container" -->
</template>



<script>

  export default {
    // data objects
    data() {
      return {
        vehicleBodys: [],
        vehicleColors: [],
        wheels: [],
        engines: []
      };
    },

    // exec func
    mounted() {
      // HTTP GET funcs
      this.getData("vehicleBodys");
      this.getData("vehicleColors");
      this.getData("wheels");
      this.getData("engines");
    },
    
    methods: {
      // HTTP GET func
      // see also https://codezup.com/how-to-fetch-data-from-rest-apis-in-vuejs-beginners-guide/
      getData(tabel) {
        fetch(`http://localhost/api/${tabel}`)
          .then(response => response.json())
          .then(data => {
            switch (tabel) {
              case "vehicleBodys": 
                this.vehicleBodys = data.data; 
                break;
              case "vehicleColors": 
                this.vehicleColors = data.data; 
                break;
              case "wheels": 
                this.wheels = data.data; 
                break;
              case "engines": 
                this.engines = data.data; 
                break;
            }
          })
          .catch(error => {
          console.error(error);
        });
      }
    }

  };

</script>

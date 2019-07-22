<template>
    <v-container v-if="loading">
        <div class="text-xs-center">
            <v-progress-circular
                indeterminate
                :size="75"
                :width="6"
                color="#1E90FF">
            </v-progress-circular>
        </div>
    </v-container>

    <v-container v-else fluid>
        <div class="center">
            <h1>My Trips</h1>
        </div>
        <v-layout row wrap class="justify-center">
            <v-flex xs7 pa-2 mb-2>
                <v-card class="rounded-card">
                    <v-container v-if="selectedItem != null">
                        <v-layout row wrap>
                            <v-flex md4 class="lg3-custom"><font-awesome-icon icon="map-marker-alt"/>&nbsp;{{selectedItem.city.name}}, {{selectedItem.country}}</v-flex>
                            <v-flex md4 class="lg3-custom"><font-awesome-icon icon="calendar-alt"/>&nbsp;{{selectedItem.date | formatDate}}</v-flex>
                            <v-flex md4 class="lg3-custom"><font-awesome-icon icon="user-alt"/>&nbsp;{{selectedItem.guest}} Guest</v-flex>
                            <v-flex md4 class="lg3-custom"><font-awesome-icon icon="crown"/>&nbsp;{{selectedItem.class}}, {{selectedItem.country}}</v-flex>
                            <v-flex md4 class="lg3-custom"><font-awesome-icon icon="credit-card"/>&nbsp;{{selectedItem.price}}€</v-flex>
                        </v-layout>
                    </v-container>
                    <v-container v-else class="center fontMedium">
                        Choose a trip
                    </v-container>
                    </v-card>
                </v-flex>    
        </v-layout>
        <v-layout row wrap class="justify-center">
            <v-flex xs7 pa-2 mb-2 v-for="(item, index) in responseApi" :key="index">
                
                <v-card class="clickable pr-4 rounded-card" @click.native="selectItem(item)">
                    <v-layout>
                        <v-flex xs3>
                            <v-card-media
                                contain
                                :src="item.thumb"
                            />
                        </v-flex>
                        <v-flex xs8>
                            <v-card-title>
                                <div>
                                    <v-rating
                                        readonly
                                        v-model="item.stars"
                                        small=True
                                        star-size="30"
                                        color="yellow darken-3"
                                        background-color="grey darken-1"
                                        empty-icon="$vuetify.icons.ratingFull"
                                        half-increments
                                    ></v-rating>
                                    <div class="headline">{{item.hotelName}}</div>
                                    <div class="grey--text">{{item.location}}, {{item.city.name}}</div>
                                </div>
                            </v-card-title>
                            <v-card-actions>
                                <v-layout align-end justify-end row fill-height>
                                    <div class="headline blue--text">{{item.price}}€</div>
                                </v-layout>
                            </v-card-actions>
                        </v-flex>
                    </v-layout>
                </v-card>
            </v-flex>                
        </v-layout>
    </v-container>
</template>

<script>

    import moment from 'moment';
    import {APIService} from '../APIService';

    const apiService = new APIService();
    
    export default {
        data () {
            return {
                responseApi: [],
                selectedItem: null,
                loading: true
            }
        },
        filters: {
            formatDate: function (value) {
                if (value) {
                    return moment(String(value)).format('MMM, DD, YYYY')
                }
            }
        },
        methods: {
            selectItem(item) {
                this.selectedItem = item;
            }
        },
        mounted () {
             apiService.getTripsByCity(132)
                .then(response => {
                    this.responseApi = response.data
                    this.loading = false
                })
                .catch(error => {
                    console.log(error)
                })
            }
        }
</script>

<style lang="stylus" scoped>
    .v-progress-circular
        margin: 1rem

    .rounded-card
        border-radius:20px;   

    .clickable
        cursor: pointer;

    .flex.lg3-custom {
        width: 33%;
        font-size: 18px;
        color : gray;
        padding-bottom : 20px;
        margin : auto;
        text-align : center;
    }
    .center {
        text-align: center;
        margin : auto;
    }
    .fontMedium {
        font-size: 18px;
    }
</style>
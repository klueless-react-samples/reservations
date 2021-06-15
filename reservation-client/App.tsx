var images: any[] = [];

for (let i = 1; i < 16; i++) {
  images.push(require(`./assets/avatars/${i}.svg`));
}

import React, { useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';

import { SearchInput, Button  } from './components';
import { search  } from './services';

export default function App() {
  const [input, setInput] = useState<string>('');
  const [reservations, setReservations] = useState([]);

  function handleGoPress() {
    search(input)
      .then((data: any) => setReservations(data));
  }

  function cell(value: any) {
    return (
      <View style={{ flex: 1, alignSelf: 'stretch' }}><Text>{value}</Text></View>
    );
  }

  function img(image: any) {
    return (
      <View style={{ flex: .2, alignSelf: 'stretch' }}><img src={image} /></View>
    );
  }

  // <Text style={{alignSelf: "flex-start"}}>{value}</Text>
  

  function renderReservations() {
    return reservations.map((m: any, index: number)=> (
      <View  key={index} style={{ flex: 1, alignSelf: 'stretch', flexDirection: 'row', backgroundColor: (index % 2 ? '#F7F6E7' : '#F1F1E1' ) }}>
                {img(images[Math.floor(Math.random() * images.length) + 1])}
                {cell(m.name)}
                {cell(m.date)}
                {cell(m.time)}
                {cell(m.noOfPeople)}
                {cell(m.phoneNumber)}
      </View>
      // <View key={index}>
      //   <Text>{m.name}</Text>
      //   <Text>{m.date}</Text>
      //   <Text>{m.time}</Text>
      //   <Text>{m.noOfPeople}</Text>
      //   <Text>{m.phoneNumber}</Text>
      // </View>
    ))
  }

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <SearchInput placeholder="Search reservations by name or phone..." value={input} onChange={setInput} />
        <Button title="GO" variant='error' onPress={()=> handleGoPress() }></Button>
      </View>
      <View style={styles.body}>
        <Text style={ styles.h1 }>Reservations will go here</Text>
        {renderReservations()}
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  header: {
    backgroundColor: 'lightseagreen',
    flexDirection: "row",
    padding: 15,
    gap: 15,

  },
  body: {
    backgroundColor: 'ivory',
    flex: 9,
  },
  h1: {
    fontSize: 25,
    color: 'white',
    fontWeight: 'bold',
    fontFamily: 'serif'
  },
});

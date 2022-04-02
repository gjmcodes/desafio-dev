import 'dart:io';

import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ByCoders Dev',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const HomePage(),
    );
  }
}

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  FilePickerResult? result;

  void pickFile() async {
    result = await FilePicker.platform.pickFiles();
    if (result != null) {
      var uri = Uri.parse('https://localhost:7290/api/transaction');

      var bytes = result?.files.single.bytes;
      var request = http.MultipartRequest("POST", uri);
      request.headers['Access-Control-Allow-Origin'] = '*';
      request.fields['file'] = 'cnab';
      List<int> _filesBytes = bytes!.map((e) => e).toList();
      request.files.add(http.MultipartFile.fromBytes('file', _filesBytes,
          contentType: MediaType('multipart', 'form-data')));

      request.send().then((response) {
        print(response);
        if (response.statusCode == 200) print("Uploaded!");
      });
    } else {
      print('user cancelled');
      // User canceled the picker
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('_ByCoders App')),
      body: Container(
        child: Center(
          child: ElevatedButton(
            child: Text('upload file'),
            onPressed: () async => {pickFile()},
          ),
        ),
      ),
    );
  }
}

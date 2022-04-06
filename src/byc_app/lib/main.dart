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

  bool isUploading = false;
  bool uploadSuccess = false;

  void pickFile() async {
    try {
      setState(() {
        isUploading = true;
      });

      result = await FilePicker.platform.pickFiles();

      if (result != null) {
        var uri = Uri.parse('http://localhost:8080/api/transaction');

        var bytes = result?.files.single.bytes;
        var request = http.MultipartRequest("POST", uri);
        request.headers['Access-Control-Allow-Origin'] = '*';
        request.fields['file'] = 'cnab';
        List<int> _filesBytes = bytes!.map((e) => e).toList();
        request.files.add(http.MultipartFile.fromBytes('file', _filesBytes,
            contentType: MediaType('multipart', 'form-data')));

        var response = await request.send();
        if (response.statusCode == 200) {
          uploadSuccess = true;
          print("Uploaded!");
        } else {
          print('user cancelled');
        }
      }

      setState(() {
        isUploading = false;
      });
    } catch (e) {
      setState(() {
        isUploading = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('_ByCoders App')),
      body: Container(
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            uploadSuccess
                ? AlertDialog(
                    title: const Text('Upload Successful'),
                    actions: [
                      TextButton(
                          onPressed: () {
                            setState(() {
                              uploadSuccess = false;
                            });
                          },
                          child: const Text('ok'))
                    ],
                  )
                : Center(
                  child: ElevatedButton(
                      child: Text(isUploading ? 'uploading...' : 'upload file'),
                      onPressed: isUploading ? null : pickFile,
                    ),
                ),
          ],
        ),
      ),
    );
  }
}
